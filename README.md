This is a demo C# Source Generator.  Note that this is just to demo the techniques required such as the source generator itself, how to reference to see in operation and how to write tests.

What does it do ?

Given a protected method that we would like to mock with Moq
```
    public abstract class MyProtected
    {
        protected abstract void AbstractMethod();
        public void InvokeAbstractMethod()
        {
            AbstractMethod();
        }
        protected abstract string AbstractMethodReturning(int value);
        public string InvokeAbstractMethodReturning(int value)
        {
            return AbstractMethodReturning(value);
        }
        protected abstract void AbstractMethodArgs(int value);
        public void InvokeAbstractMethodArgs(int value)
        {
            AbstractMethodArgs(value);
        }
    }
```

Enable strongly typed extension methods where you can supply parameter matchers as method arguments.
```
    var mock = new Mock<MyProtected>();
    mock.AbstractMethod().Build().Setup().Throws(new ExpectedException());
    Assert.Throws<ExpectedException>(() => mock.Object.InvokeAbstractMethod());

    void Verify()
    {
        mock.AbstractMethodArgs(It.IsInRange(1, 10, Moq.Range.Inclusive)).Build().Verify();
    }

    mock.Object.InvokeAbstractMethodArgs(999);
    Assert.Throws<MockException>(Verify);

    mock.Object.InvokeAbstractMethodArgs(1);
    Verify();

    mock.AbstractMethodReturning(1).Build().Setup().Returns("One");
    mock.AbstractMethodReturning(2).Build().Setup().Returns("Two");
    Assert.That(mock.Object.InvokeAbstractMethodReturning(1), Is.EqualTo("One"));
    Assert.That(mock.Object.InvokeAbstractMethodReturning(2), Is.EqualTo("Two"));

```
How it works

For every method a static class is generated that provides an extension method to the applicable Mock.
Below we see the method `AbstractMethodReturning(this Mock<MyProtected> mock, int value)` matches protected abstract method on `MyProtected`.
It ignores the paramer as instead the source generator also reads the arguments to the extension method and stores them with the file and line number.  ( Of course this has its limitations )
These values are then matched against those provided by the compiler to the Build method of the extension method return type and subsequently used in the Setup or Verify that follows Build in the chain.
`mock.AbstractMethodReturning(1).Build().Setup().Returns("One");`



```
public static class MyProtected_AbstractMethodReturning
{
    private static readonly Dictionary<string, Expression<Func<MyProtectedLike,string>>> Setups =
        new Dictionary<string, Expression<Func<MyProtectedLike,string>>>
        {
            {
                @"C:\Users\tonyh\source\repos\MoqProtectedSourceGenerator\TestWithGenerator\Test.cs_51",
                like => like.AbstractMethodReturning(1)
            },
            {
                @"C:\Users\tonyh\source\repos\MoqProtectedSourceGenerator\TestWithGenerator\Test.cs_52",
                like => like.AbstractMethodReturning(2)
            }
        };
    private static readonly Dictionary<string, Expression<Func<MyProtectedLike,string>>> Verifications =
        new Dictionary<string, Expression<Func<MyProtectedLike,string>>>{};

    private static string GetKey(string sourceFileInfo, int sourceLineNumber)
    {
        return sourceFileInfo + "_" + sourceLineNumber;
    }

    public static IReturningMethodBuilder<MyProtected, string> AbstractMethodReturning(this Mock<MyProtected> mock, int value)
    {
        return new ReturningMethodBuilder<MyProtected,string>(
            (sourceFileInfo, sourceLineNumber) => mock.Protected().As<MyProtectedLike>().Setup(Setups[GetKey(sourceFileInfo, sourceLineNumber)]),
            (sourceFileInfo, sourceLineNumber, times, failMessage) => mock.Protected().As<MyProtectedLike>().Verify(Verifications[GetKey(sourceFileInfo, sourceLineNumber)], times, failMessage)
        );
    }
}

```

The base class has all the functionality.  It passes the compiler args to the constructor setup or verify.
Looking at the extension method above you can see that what as returned when Setup or Verify is called is a regular Moq Setup or Verify.
```
    public class SetupVerifyBuilder<TSetup> : ISetupVerifyBuilder<TSetup>, ISetupVerify<TSetup>
    {
        private readonly Func<string, int, TSetup> setup;
        private readonly Action<string, int, Times?, string> verify;
        private string sourceFilePath;
        private int sourceLineNumber;

        public SetupVerifyBuilder(Func<string, int, TSetup> setup, Action<string, int, Times?, string> verify)
        {
            this.setup = setup;
            this.verify = verify;
        }

        public ISetupVerify<TSetup> Build([System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            this.sourceFilePath = sourceFilePath;
            this.sourceLineNumber = sourceLineNumber;
            return this;
        }

        public TSetup Setup()
        {
            return setup(sourceFilePath, sourceLineNumber);
        }

        public void Verify(Times? times = null, string failMessage = null)
        {
            verify(sourceFilePath, sourceLineNumber, times, failMessage);
        }
    }

```


To use `mock.Protected().As<>` the "like" interface is generated with the correct shape.

```
    internal interface MyProtectedLike{
        void AbstractMethod();
        string AbstractMethodReturning(int value);
        void AbstractMethodArgs(int value);
    }
```
