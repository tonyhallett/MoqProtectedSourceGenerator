A code generator that generates extension methods to enable working with Moq's protected mocks in a type safe manner.

It accomplishes this in two ways but common to both is the generation of the "like" interface that would be used in code similar to below.

```
mock.Protected().As<{likeType}>()
```

The code generator creates the ProtectedTyped extension method that provides the code above to the generated like interface.

```
internal static IProtectedAsMock<{mockType},{likeType}> ProtectedTyped(this Mock<{mockType}> mock){{
        return mock.Protected().As<{likeType}>();              
    }}");
```

When using the extension method you use Moq as normal with expressions and actions.

The second type of extension method generated facilitates set ups that do not use expressions.

With these extensions it is not possible to get automocking of hierarchies and there is a limitation with ref parameters as well as a different means of specifying out parameters.
Note that these extensions work through the compiler attributes CallerFilePath and CallerLineNumber ( the Build method ) that are not available to .NET Framework < 4.5.

For the generator to generate these extensions the nuget package MoqProtectedTyped and its ProtectedMock type need to be used.

Below are examples of using ProtectedMock and the extension methods generated on it.

Methods ( without ref or out parameters)

Extension methods are created for each protected method that accept the same parameter types.
The extension method is then followed by `Build()` and then Setup / SetupSequence or Verify.
Aside from the Setup method having no expression the return type behaves similarly to normal Moq for fluent method chaining but has the added 
advantage that callbacks are overloaded to only the applicable overloads for the particular method.
For refs and outs the generator will create the delegate for you.
For methods with async returns the ReturnsAsync provides some of the overloads that are missing from Moq ReturnsExtensions and also limits 
overloads similarly to how Callback is restricted.
```
public abstract class ProtectedDemo
{
    protected abstract void VoidMethodNoParameters();
    protected abstract int ReturningMethodWithParameters(int p1, string p2);
    public void InvokeVoidMethodNoParameters()
    {
        VoidMethodNoParameters();
    }
    public int InvokeReturningMethodWithParameters(int p1, string p2)
    {
        return ReturningMethodWithParameters(p1, p2);
    }

}

public class Test
{
    [Test]
    public void Protected_Readme_Demo()
    {
        var protectedMock = new ProtectedMock<ProtectedDemo>();
        var protectedMocked = protectedMock.Object;
        protectedMock.VoidMethodNoParameters().Build().Setup().Throws(new ExpectedException());
        Assert.Throws<ExpectedException>(() => protectedMocked.InvokeVoidMethodNoParameters());

        int p1 = 0;
        string p2 = null;
        // Callback overloads are restricted to those applicable to the method
        protectedMock.ReturningMethodWithParameters(1, It.IsAny<string>())
            .Build().Setup().Callback((i, s) =>
            {
                p1 = i;
                p2 = s;
            }).Returns(123);
        protectedMocked.InvokeReturningMethodWithParameters(1, "Two");
        Assert.AreEqual(1, p1);
        Assert.AreEqual("Two", p2);

        void VerifyExample()
        {
            protectedMock.ReturningMethodWithParameters(0, "0").Build().Verify();
        }
        Assert.Throws<MockException>(VerifyExample);
        protectedMocked.InvokeReturningMethodWithParameters(0, "0");
        VerifyExample();

        protectedMock.ReturningMethodWithParameters(It.IsAny<int>(), "Seq")
            .Build().SetupSequence().Returns(1).Returns(2).Throws(new ExpectedException());
        Assert.AreEqual(1, protectedMocked.InvokeReturningMethodWithParameters(0, "Seq"));
        Assert.AreEqual(2, protectedMocked.InvokeReturningMethodWithParameters(2, "Seq"));
        Assert.Throws<ExpectedException>(() => protectedMocked.InvokeReturningMethodWithParameters(4, "Seq"));
    }
}
```

Custom matchers

To use your own custom matcher it is necessary to wrap it.

```
public static class MyCustomMatcher
{
    public static int GreaterThan(int value)
    {
        return Match.Create<int>(v => v > value);
    }
}

// Add to Test class
protectedMock.ReturningMethodWithParameters(
    CustomMatcher.Wrap(MyCustomMatcher.GreaterThan, 1000),
    "custom matcher"
).Build().Setup().Returns(456);

Assert.AreEqual(0, protectedMocked.InvokeReturningMethodWithParameters(1000, "custom matcher"));
Assert.AreEqual(456, protectedMocked.InvokeReturningMethodWithParameters(1001, "custom matcher"));

```


Out parameters

The extension method parameter types differ to the protected method.
Out parameters are replaced with `Out<ParameterType>` that you supply with `Out.From(value)`

```
// adding to the ProtectedDemo class
    protected abstract void MethodWithOut(out int outP);
    public void InvokeMethodWithOut(out int outP)
    {
        MethodWithOut(out outP);
    }
// adding to the Test class
    protectedMock.MethodWithOut(Out.From(1)).Build().Setup();
    protectedMocked.InvokeMethodWithOut(out var outP);
    Assert.AreEqual(1, outP);
```

Ref limitation
Ref parameters only work with It.Ref...
```
It.Ref<int>.IsAny
It.Ref<It.IsSubtype<SubType1>>.IsAny
```

Properties

Properties are slightly different to methods.  The property name is an extension method that is then followed by Get and/or Set as is appropriate 
and SetupProperty if the property has get and set accessors.
The Set method takes the property value as argument.  If the property is an indexer then get and set have the keys as arguments.
Get and Set are then followed by Build in the same manner as methods.

```
// adding to the ProtectedDemo class
    protected abstract int Property { get; set; }
    public int GetProperty()
    {
        return Property;
    }
    public void SetProperty(int value)
    {
        Property = value;
    }

// adding to the Test class
    protectedMock.Property().Get().Build().Setup().Returns(1);
    Assert.AreEqual(1, protectedMocked.GetProperty());
    protectedMock.Property().Set(It.Is<int>(v => v == 999)).Build().Setup().Throws(new ExpectedException());
    protectedMocked.SetProperty(1);
    Assert.Throws<ExpectedException>(() => protectedMocked.SetProperty(999));
    protectedMock.Property().SetupProperty();
    protectedMocked.SetProperty(123);
    Assert.AreEqual(123, protectedMocked.GetProperty());

```

Indexers

The extension method name for indexers that do not have the `System.Runtime.CompilerServices.IndexerNameAttribute` applied 
is Item.  If there are overloaded indexers then there will be a numeric suffix - e.g Item_1.  By checking the generic type parameters 
of the return type it is possible to distinguish the overload that the extension represents.

IndexerNameAttribute

When the IndexerNameAttribute has been supplied then the extension name will default to that from the attribute ( with the suffix for overloaded indexers ).
If this is not the desired behaviour the code generator has an options for this.
// todo add link to options
To specify in your project file add the following property:
```
<MoqProtectedSourceGenerator_IndexerExtensionNameFromIndexerNameAttribute>false</MoqProtectedSourceGenerator_IndexerExtensionNameFromIndexerNameAttribute>
```
_
Other options

By default the generated classes containing the extension methods are in the global namespace.
If you set the following option to false then you will need to add `using MoqProtectedGenerated;`
```
<MoqProtectedSourceGenerator_GlobalExtensions>true</MoqProtectedSourceGenerator_GlobalExtensions>
```

