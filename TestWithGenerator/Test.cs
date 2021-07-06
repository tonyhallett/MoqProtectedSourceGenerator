using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DifferentNamespace;
using IFace;
using Moq;
using MoqProtectedTyped;
using NUnit.Framework;
using OtherNamespace;
using MoqProtectedGenerated;
using Moq.Language.Flow;
using System.Linq;

namespace ClassLibrary1
{
    public abstract class MyProtected
    {
        protected abstract void OutMethod(out int outInt);
        protected abstract void AbstractMethod();

        protected abstract string RefGeneric<T>(ref T t);
        protected abstract string Ref(ref int refInt,string other);
        protected abstract int DuplicateGenericDelegate(ref string refStr, int other);

        protected abstract string GenericNoConstraints<T>(T t);
        protected abstract string GenericNoConstraintsMultipleArgs<T>(T t1, T t2);

        protected abstract string NullIt(IInterface arg);

        public void InvokeAbstractMethod()
        {
            AbstractMethod();
        }
        protected abstract void AbstractMethodArgs(int value);
        public void InvokeAbstractMethodArgs(int value)
        {
            AbstractMethodArgs(value);
        }

        public void InvokeOutMethod(out int outInt)
        {
            OutMethod(out outInt);
        }

        public string InvokeRefGeneric<T>(ref T t)
        {
            return RefGeneric(ref t);
        }

        public string InvokeRef(ref int refInt,string other)
        {
            return Ref(ref refInt,other);
        }

        public string InvokeNullIt(IInterface arg)
        {
            return NullIt(arg);
        }

        public string InvokeGenericNoConstraints<T>(T t)
        {
            return GenericNoConstraints(t);
        }
        public string InvokeGenericNoConstraintsMultipleArgs<T>(T t1, T t2)
        {
            return GenericNoConstraintsMultipleArgs(t1, t2);
        }

        protected abstract string Overloaded(int intParam);
        protected abstract string Overloaded(string stringParam);
        public string InvokeOverloaded(int intParam)
        {
            return Overloaded(intParam);
        }
        public string InvokeOverloaded(string stringParam)
        {
            return Overloaded(stringParam);
        }

        protected abstract string OverloadedGeneric<T>(T t, int intParam);
        protected abstract string OverloadedGeneric<T>(T t, string stringParam);

        protected abstract string Stub { get; set; }
        public string GetStub()
        {
            return Stub;
        }

        public void SetStub(string value)
        {
            Stub = value;
        }


        protected abstract string GetSet { get; set; }

        public string GetGetSet()
        {
            return GetSet;
        }

        public void SetGetSet(string value)
        {
            GetSet = value;
        }

        protected abstract string GetOnly { get; }
        public string GetGetOnly()
        {
            return GetOnly;
        }

        protected abstract string SetOnly { set; }
        public void SetSetOnly(string value)
        {
            SetOnly = value;
        }
        [System.Runtime.CompilerServices.IndexerName("MyIndexer")]
        protected abstract string this[int key] { get;set; }
        [System.Runtime.CompilerServices.IndexerName("MyIndexer")]
        protected abstract string this[string key] { get; set; }
        [System.Runtime.CompilerServices.IndexerName("MyIndexer")]
        protected abstract Task<int> this[decimal key] { get; set; }

        public Task<int> GetTaskIndex(decimal key)
        {
            return this[key];
        }
        public string GetIndex(int key)
        {
            return this[key];
        }
        public void SetIndex(int key,string value)
        {
            this[key] = value;
        }

        protected abstract Task TaskProperty { get; set; }
        public Task GetTaskProperty()
        {
            return TaskProperty;
        }
        protected abstract ValueTask ValueTaskProperty { get; set; }
        protected abstract Task<int> TaskResultProperty { get; set; }
        public Task<int> GetTaskResultProperty()
        {
            return TaskResultProperty;
        }
        protected abstract ValueTask<int> ValueTaskResultProperty { get; set; }

        protected abstract Task<int> TaskInt();
        protected abstract Task<string> TaskStringWithParameters(int p1, string p2);

        public Task<int> InvokeTaskInt()
        {
            return TaskInt();
        }

        public Task<string> InvokeTaskStringWithParameters(int p1, string p2)
        {
            return TaskStringWithParameters(p1, p2);
        }

        protected abstract Task Task();
        public Task InvokeTask()
        {
            return Task();
        }
        protected abstract ValueTask<int> ValueTaskResult();
        public ValueTask<int> InvokeValueTaskResult()
        {
            return ValueTaskResult();
        }

        protected abstract ValueTask ValueTask();
        public ValueTask InvokeValueTask()
        {
            return ValueTask();
        }
    }

    public class ExpectedException : Exception { }
    public class Implementation : IInterface
    {
    }


    public abstract class SubType1 { }
    public class Derivation1 : SubType1 { }
    public abstract class SubType2 { }
    public class Derivation2 : SubType2 { }

    public abstract class Duplicate
    {
        protected abstract string Dupe(int value);
        public string Invoke(int value)
        {
            return Dupe(value);
        }
    }

    [TypeMatcher]
    public sealed class GenericParameterIsIntOrString : ITypeMatcher
    {
        public bool Matches(Type typeArgument)
        {
            if (typeArgument != this.GetType())
            {
                var genericArgument = typeArgument.GetGenericArguments()[0];
                var match = genericArgument == typeof(int) || genericArgument == typeof(string);
                return match;
            }
            return false;
        }
    }

    public static class MyCustomMatcher
    {
        public static int GreaterThan(int value)
        {
            return Match.Create<int>(v => v > value);
        }
    }

    public class Test
    {
        [Test]
        public async Task Generate()
        {
            var mock = new ProtectedMock<MyProtected>();

            mock.Overloaded(999).Build().Setup().Returns("999");
            Assert.AreEqual("999", mock.Object.InvokeOverloaded(999));

            mock.Overloaded("123").Build().Setup().Returns("123");
            Assert.AreEqual("123", mock.Object.InvokeOverloaded("123"));

            Assert.Throws<MockException>(() => mock.Overloaded(It.IsInRange(0, 5, Moq.Range.Inclusive)).Build().Verify());
            mock.Object.InvokeOverloaded(1);
            mock.Overloaded(It.IsInRange(0, 5, Moq.Range.Inclusive)).Build().Verify();

            mock.OverloadedGeneric(1, 1).Build().Setup();
            mock.OverloadedGeneric("1", 1).Build().Setup();

            mock.AbstractMethod().Build().Setup().Throws(new ExpectedException());
            //mock.AbstractMethod().Build().Setup().Callback(a => { }) // Delegate 'Action' does not take 1 arguments
            //mock.AbstractMethod().Build("", 0).Setup();// build error *************
            //mock.AbstractMethod().Build();//build error ************
            Assert.Throws<ExpectedException>(() => mock.Object.InvokeAbstractMethod());

            mock.AbstractMethodArgs(999).Build().Setup();
            mock.AbstractMethodArgs(123).Build().Setup();
            void Verify()
            {
                mock.AbstractMethodArgs(It.IsInRange(1, 10, Moq.Range.Inclusive)).Build().Verify();
            }

            mock.Object.InvokeAbstractMethodArgs(999);
            Assert.Throws<MockException>(Verify);

            mock.Object.InvokeAbstractMethodArgs(1);
            Verify();

            var calledBack = false;
            //Action allowed for all 
            mock.AbstractMethodArgs(456).Build().Setup().Callback(() => calledBack = true);
            mock.Object.InvokeAbstractMethodArgs(456);
            Assert.True(calledBack);
            var callbackArg = 0;
            mock.AbstractMethodArgs(789).Build().Setup().Callback((a) => callbackArg = a);
            mock.Object.InvokeAbstractMethodArgs(789);
            Assert.AreEqual(789, callbackArg);

            var mockOut = new ProtectedMock<MyProtected>();
            mockOut.OutMethod(Out.From(123)).Build().Setup();
            mockOut.Object.InvokeOutMethod(out var outInt);
            Assert.AreEqual(123, outInt);

            var mockOutCallback = new ProtectedMock<MyProtected>();
            // generated callback for out !
            mockOutCallback.OutMethod(Out.From(0)).Build().Setup().Callback((out int o) => o = 999);
            mockOutCallback.Object.InvokeOutMethod(out var outInt2);
            Assert.AreEqual(999, outInt2);


            var mockNullIt = new ProtectedMock<MyProtected>();
            mockNullIt.NullIt(It.IsAny<IInterface>()).Build().Setup().Returns("Match");
            Assert.AreEqual("Match", mockNullIt.Object.InvokeNullIt(new Implementation()));

            var mockGenericNoConstraints = new ProtectedMock<MyProtected>();
            mockGenericNoConstraints.GenericNoConstraints<Implementation>(null).Build().Setup().Returns("Impl null");
            Assert.AreEqual("Impl null", mockGenericNoConstraints.Object.InvokeGenericNoConstraints<Implementation>(null));

            mockGenericNoConstraints.GenericNoConstraints(null as string).Build().Setup().Returns("string null");
            Assert.AreEqual("string null", mockGenericNoConstraints.Object.InvokeGenericNoConstraints(null as string));

            string genericCallbackBefore = null;
            string genericCallbackAfter = null;
            mockGenericNoConstraints.GenericNoConstraints(It.Is<string>(s => s == "match")).Build().Setup().
                Callback(s => genericCallbackBefore = s).Returns("matcher").Callback(s => genericCallbackAfter = s);
            Assert.AreEqual("matcher", mockGenericNoConstraints.Object.InvokeGenericNoConstraints("match"));
            Assert.AreEqual("match", genericCallbackBefore);
            Assert.AreEqual("match", genericCallbackAfter);

            mockGenericNoConstraints.GenericNoConstraints(CustomMatcher.Wrap(MyCustomMatcher.GreaterThan, 1000)).Build().Setup().Returns("custom matcher");
            Assert.AreEqual("custom matcher", mockGenericNoConstraints.Object.InvokeGenericNoConstraints(1001));

            mockGenericNoConstraints.GenericNoConstraints(It.IsAny<GenericParameterIsIntOrString>()).Build().Setup().Returns("custom type matcher");
            Assert.AreEqual("custom type matcher", mockGenericNoConstraints.Object.InvokeGenericNoConstraints(new List<string>()));

            mockGenericNoConstraints.GenericNoConstraints(It.IsAny<It.IsSubtype<SubType1>>()).Build().Setup().Returns("sub type");
            Assert.AreEqual("sub type", mockGenericNoConstraints.Object.InvokeGenericNoConstraints(new Derivation1()));

            var mockRef = new ProtectedMock<MyProtected>();
            // type returns !
            mockRef.Ref(ref It.Ref<int>.IsAny,It.IsAny<string>()).Build().Setup().Returns((ref int r,string other) => other);
            var refInt = 0;
            Assert.AreEqual("other", mockRef.Object.InvokeRef(ref refInt,"other")); 

            //mockRef.Ref(ref refInt).Build().Setup(); // build error ***************************************

            var mockRefGeneric = new ProtectedMock<MyProtected>();
            mockRefGeneric.RefGeneric(ref It.Ref<It.IsSubtype<SubType1>>.IsAny).Build().Setup().Returns("subtype1");
            var refSubType1 = new Derivation1();
            Assert.AreEqual("subtype1", mockRefGeneric.Object.InvokeRefGeneric(ref refSubType1));
            mockRefGeneric.RefGeneric(ref It.Ref<It.IsSubtype<SubType2>>.IsAny).Build().Setup().Returns("subtype2");
            var refSubType2 = new Derivation2();
            Assert.AreEqual("subtype2", mockRefGeneric.Object.InvokeRefGeneric(ref refSubType2));

            mockRefGeneric.RefGeneric(ref It.Ref<It.IsSubtype<DifferentNamespaceClass>>.IsAny).Build().Setup().Returns("different namespace");
            var refDifferentNamespace = new DifferentNamespaceClass();
            Assert.AreEqual("different namespace", mockRefGeneric.Object.InvokeRefGeneric(ref refDifferentNamespace));

            var mockDll = new ProtectedMock<ProtectedDll.DllProtected>();


            var impl = new Implementation();
            mockDll.ProtectedGenericMethod(null, impl).Build().Setup().Throws(new ExpectedException());
            Assert.Throws<ExpectedException>(() => mockDll.Object.CallProtectedGenericMethod(null, impl));
            mockDll.Object.CallProtectedGenericMethod(new Implementation(), new Implementation());

            var mockGenericMultipleNoConstraints = new ProtectedMock<MyProtected>();
            mockGenericMultipleNoConstraints.GenericNoConstraintsMultipleArgs(null, "arg").Build().Setup().Returns("match");
            Assert.AreEqual("match", mockGenericMultipleNoConstraints.Object.InvokeGenericNoConstraintsMultipleArgs(null, "arg"));
            mockGenericMultipleNoConstraints.GenericNoConstraintsMultipleArgs(null, It.Is<string>(s => s == "match")).Build().Setup().Returns("matcher");
            Assert.AreEqual("matcher", mockGenericMultipleNoConstraints.Object.InvokeGenericNoConstraintsMultipleArgs(null, "match"));
            var intCallback = 0;
            mockGenericMultipleNoConstraints.GenericNoConstraintsMultipleArgs(1, 2).Build().Setup().Callback((a1, a2) => intCallback = a1 + a2);
            string stringCallback = null;
            mockGenericMultipleNoConstraints.GenericNoConstraintsMultipleArgs("1", "2").Build().Setup().Callback((a1, a2) => stringCallback = a1 + a2);

            mockDll.ProtectedGenericMethod(It.IsAny<Implementation>(), It.IsAny<Implementation>()).Build().Setup().Throws(new ExpectedException());
            Assert.Throws<ExpectedException>(() => mockDll.Object.CallProtectedGenericMethod(new Implementation(), new Implementation()));


            mockDll.ProtectedMethod(It.IsAny<Other>(), "match").Build().Setup().Throws(new ExpectedException());
            mockDll.Object.CallProtectedMethod(new Other(), "not a match");
            Assert.Throws<ExpectedException>(() => mockDll.Object.CallProtectedMethod(new Other(), "match"));

            var mockDuplicate = new ProtectedMock<Duplicate>();
            mockDuplicate.Dupe(0).Build().Setup().Returns("First");
            var mockDuplicateDll = new ProtectedMock<ProtectedDll.Duplicate>();
            mockDuplicateDll.Dupe(0).Build().Setup().Returns("Second");
            Assert.AreEqual("First", mockDuplicate.Object.Invoke(0));
            Assert.AreEqual("Second", mockDuplicateDll.Object.Invoke(0));

            var mockSequenced = new ProtectedMock<MyProtected>();
            mockSequenced.AbstractMethod().Build().SetupSequence().Pass().Throws(new ExpectedException());
            mockSequenced.Object.InvokeAbstractMethod();
            Assert.Throws<ExpectedException>(() => mockSequenced.Object.InvokeAbstractMethod());

            var mockSequencedReturns = new ProtectedMock<MyProtected>();
            mockSequencedReturns.GenericNoConstraints(It.IsAny<int>()).Build().SetupSequence().Returns("1").Returns("2").Throws(new ExpectedException());
            Assert.AreEqual("1", mockSequencedReturns.Object.InvokeGenericNoConstraints(1));
            Assert.AreEqual("2", mockSequencedReturns.Object.InvokeGenericNoConstraints(1));
            Assert.Throws<ExpectedException>(() => mockSequencedReturns.Object.InvokeGenericNoConstraints(1));
            mockSequencedReturns.GenericNoConstraints("");

            var mockProperties = new ProtectedMock<MyProtected>();
            var mockedProperties = mockProperties.Object;
            mockProperties.GetSet().Get().Build().Setup().Returns("getter");
            Assert.Throws<MockException>(() => mockProperties.GetSet().Get().Build().Verify());
            Assert.AreEqual("getter", mockedProperties.GetGetSet());
            mockProperties.GetSet().Get().Build().Verify();

            mockProperties.GetSet().Set("throw").Build().Setup().Throws(new ExpectedException());
            mockedProperties.SetGetSet("ok");
            Assert.Throws<ExpectedException>(() => mockedProperties.SetGetSet("throw"));

            mockProperties.GetOnly().Get().Build().Setup().Returns("getter");
            Assert.AreEqual("getter", mockedProperties.GetGetOnly());

            mockProperties.SetOnly().Set("throw").Build().Setup().Throws(new ExpectedException());
            mockedProperties.SetSetOnly("ok");
            Assert.Throws<ExpectedException>(() => mockedProperties.SetSetOnly("throw"));

            mockProperties.Stub().SetupProperty("initial value");
            Assert.AreEqual("initial value", mockedProperties.GetStub());
            mockedProperties.SetStub("new");
            Assert.AreEqual("new", mockedProperties.GetStub());

            var mockPropertiesSequence = new ProtectedMock<MyProtected>();
            var mockedPropertiesSequence = mockPropertiesSequence.Object;
            mockPropertiesSequence.GetSet().Get().Build().SetupSequence().Returns("1").Returns("2").Throws(new ExpectedException());
            Assert.AreEqual("1", mockedPropertiesSequence.GetGetSet());
            Assert.AreEqual("2", mockedPropertiesSequence.GetGetSet());
            Assert.Throws<ExpectedException>(() => mockedPropertiesSequence.GetGetSet());

            mockPropertiesSequence.GetSet().Set("match").Build().SetupSequence().Pass().Pass().Throws(new ExpectedException());
            mockedPropertiesSequence.SetGetSet("match");
            mockedPropertiesSequence.SetGetSet("match");
            Assert.Throws<ExpectedException>(() => mockedPropertiesSequence.SetGetSet("match"));

            var mockIndex = new ProtectedMock<MyProtected>();
            var mockedIndex = mockIndex.Object;
            mockIndex.Item_1().Get(1).Build().Setup().Returns("One");
            Assert.Null(mockedIndex.GetIndex(0));
            Assert.AreEqual("One", mockedIndex.GetIndex(1));
            mockIndex.Item_1().Set(1, It.Is<string>(v => v == "match")).Build().Setup().Throws(new ExpectedException());
            mockedIndex.SetIndex(1, "not a match");
            Assert.Throws<ExpectedException>(() => mockedIndex.SetIndex(1, "match"));

            var mockIndexSequence = new ProtectedMock<MyProtected>();
            var mockedIndexSequence = mockIndexSequence.Object;
            mockIndexSequence.Item_1().Get(1).Build().SetupSequence().Returns("One").Returns("Two").Throws(new ExpectedException());
            Assert.AreEqual("One", mockedIndexSequence.GetIndex(1));
            Assert.AreEqual("Two", mockedIndexSequence.GetIndex(1));
            Assert.Throws<ExpectedException>(() => mockedIndexSequence.GetIndex(1));

            mockIndexSequence.Item_1().Set(1, It.Is<string>(v => v == "match")).Build().SetupSequence().Pass().Pass().Throws(new ExpectedException());
            mockedIndexSequence.SetIndex(1,"match");
            mockedIndexSequence.SetIndex(1, "match");
            Assert.Throws<ExpectedException>(() => mockedIndexSequence.SetIndex(1, "match"));
            mockedIndexSequence.SetIndex(1, "not a match");

            Assert.Throws<MockException>(() => mockIndexSequence.Item_1().Set(It.IsInRange(10, 15, Moq.Range.Inclusive), "x").Build().Verify());
            mockedIndexSequence.SetIndex(11, "x");
            mockIndexSequence.Item_1().Set(It.IsInRange(10, 15, Moq.Range.Inclusive), "x").Build().Verify();

            Assert.Throws<MockException>(() => mockIndexSequence.Item_1().Get(It.IsInRange(10, 15, Moq.Range.Inclusive)).Build().Verify());
            mockedIndexSequence.GetIndex(11);
            mockIndexSequence.Item_1().Get(It.IsInRange(10, 15, Moq.Range.Inclusive)).Build().Verify();

            var mockCallback = new ProtectedMock<MyProtected>();
            var mockedCallbackAndReturns = mockCallback.Object;
            int get = 0;
            mockCallback.Item_1().Get(It.IsAny<int>()).Build().Setup().Callback(g => get = g);
            mockedCallbackAndReturns.GetIndex(1);
            Assert.AreEqual(1, get);

            int get1 = 0;
            string set = null;
            mockCallback.Item_1().Set(It.IsAny<int>(), It.IsAny<string>()).Build().Setup().Callback((g,s) => {
                get1 = g;
                set = s;
            });
            mockedCallbackAndReturns.SetIndex(1,"value");
            Assert.AreEqual(1, get1);
            Assert.AreEqual("value", set);

            var mockReturn = new ProtectedMock<MyProtected>();
            var mockedReturn = mockReturn.Object;
            mockReturn.Item_1().Get(It.IsAny<int>()).Build().Setup().Returns(v => v.ToString());
            Assert.AreEqual("0", mockedReturn.GetIndex(0));
            Assert.AreEqual("1", mockedReturn.GetIndex(1));

            var asyncMock = new ProtectedMock<MyProtected>();
            var asyncMocked = asyncMock.Object;
            //taskResultMock.TaskInt().Build().Setup().Throws() - no Throws !
            asyncMock.TaskInt().Build().Setup().ThrowsAsync<ExpectedException>();
            Assert.ThrowsAsync<ExpectedException>(async () => await asyncMocked.InvokeTaskInt());
            asyncMock.ValueTaskResult().Build().Setup().ThrowsAsync(new ExpectedException());
            Assert.ThrowsAsync<ExpectedException>(async () => await asyncMocked.InvokeValueTaskResult());
            //overloads with delays
            asyncMock.Task().Build().Setup().ThrowsAsync(new ExpectedException(), TimeSpan.FromSeconds(1));
            Assert.ThrowsAsync<ExpectedException>(async () => await asyncMocked.InvokeTask());
            // new throws for ValueTask
            asyncMock.ValueTask().Build().Setup().ThrowsAsync<ExpectedException>();
            Assert.ThrowsAsync<ExpectedException>(async () => await asyncMocked.InvokeValueTask());


            var taskMock = new ProtectedMock<MyProtected>();
            var taskMocked = taskMock.Object;
            // new delays for Task
            taskMock.Task().Build().Setup().ReturnsAsync(TimeSpan.FromMilliseconds(10));
            await taskMocked.InvokeTask();
            // new delays for ValueTask
            taskMock.ValueTask().Build().Setup().ReturnsAsync(TimeSpan.FromMilliseconds(10), TimeSpan.FromMilliseconds(100));
            await taskMocked.InvokeValueTask();

            var propertyGetInvoked = false;
            taskMock.TaskProperty().Get().Build().Setup().ReturnsAsync(TimeSpan.FromMilliseconds(100)).Callback(() => propertyGetInvoked = true);
            await taskMocked.GetTaskProperty();
            Assert.True(propertyGetInvoked);
            taskMock.TaskResultProperty().Get().Build().Setup().ThrowsAsync(new ExpectedException(), TimeSpan.FromMilliseconds(100));
            Assert.ThrowsAsync<ExpectedException>(async () => await taskMocked.GetTaskResultProperty());


            var taskResultMock = new ProtectedMock<MyProtected>();
            var mockedTaskResult = taskResultMock.Object;

            var invocationCount = 0;
            Func<int> returner = () => invocationCount++;
            taskResultMock.TaskInt().Build().Setup().ReturnsAsync(returner);
            Assert.AreEqual(0, await mockedTaskResult.InvokeTaskInt());
            Assert.AreEqual(1, await mockedTaskResult.InvokeTaskInt());

            taskResultMock.TaskStringWithParameters(1, It.IsAny<string>()).Build().Setup().ReturnsAsync((i, s) => s + i.ToString(), TimeSpan.FromSeconds(1));
            var taskResult = mockedTaskResult.InvokeTaskStringWithParameters(1, "Hello");
            Assert.True(!taskResult.IsCompleted);
            Assert.AreEqual("Hello1", await taskResult);

            taskResultMock.Item_3().Get(1.1m).Build().Setup().ReturnsAsync(123);
            var taskIndexResult = await mockedTaskResult.GetTaskIndex(1.1m);
            Assert.AreEqual(123, taskIndexResult);
        }
        
    }

}
