using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DifferentNamespace;
using IFace;
using Moq;
using Moq.Protected;
using MoqProtectedTyped;
using NUnit.Framework;
using OtherNamespace;

namespace ClassLibrary1
{
    public abstract class MyProtected
    {
        protected abstract void OutMethod(out int outInt);
        protected abstract void AbstractMethod();

        protected abstract string RefGeneric<T>(ref T t);
        protected abstract string Ref(ref int refInt);

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

        public string InvokeRef(ref int refInt)
        {
            return Ref(ref refInt);
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
    }

    public class ExpectedException : Exception { }
    public class Implementation : IInterface { }


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
        public void Generate()
        {
            var mock = new ProtectedMock<MyProtected>();

            mock.Overloaded(999).Build().Setup().Returns("999");
            Assert.AreEqual("999", mock.Object.InvokeOverloaded(999));

            mock.Overloaded("123").Build().Setup().Returns("123");
            Assert.AreEqual("123", mock.Object.InvokeOverloaded("123"));

            mock.OverloadedGeneric(1, 1).Build().Setup();
            mock.OverloadedGeneric("1", 1).Build().Setup();

            mock.AbstractMethod().Build().Setup().Throws(new ExpectedException());
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

            var mockOut = new ProtectedMock<MyProtected>();
            mockOut.OutMethod(Out.From(123)).Build().Setup();
            mockOut.Object.InvokeOutMethod(out var outInt);
            Assert.AreEqual(123, outInt);

            var mockNullIt = new ProtectedMock<MyProtected>();
            mockNullIt.NullIt(It.IsAny<IInterface>()).Build().Setup().Returns("Match");
            Assert.AreEqual("Match", mockNullIt.Object.InvokeNullIt(new Implementation()));

            var mockGenericNoConstraints = new ProtectedMock<MyProtected>();
            mockGenericNoConstraints.GenericNoConstraints<Implementation>(null).Build().Setup().Returns("Impl null");
            Assert.AreEqual("Impl null", mockGenericNoConstraints.Object.InvokeGenericNoConstraints<Implementation>(null));

            mockGenericNoConstraints.GenericNoConstraints(null as string).Build().Setup().Returns("string null");
            Assert.AreEqual("string null", mockGenericNoConstraints.Object.InvokeGenericNoConstraints(null as string));

            mockGenericNoConstraints.GenericNoConstraints(It.Is<string>(s => s == "match")).Build().Setup().Returns("matcher");
            Assert.AreEqual("matcher", mockGenericNoConstraints.Object.InvokeGenericNoConstraints("match"));

            mockGenericNoConstraints.GenericNoConstraints(CustomMatcher.Wrap(MyCustomMatcher.GreaterThan, 1000)).Build().Setup().Returns("custom matcher");
            Assert.AreEqual("custom matcher", mockGenericNoConstraints.Object.InvokeGenericNoConstraints(1001));

            mockGenericNoConstraints.GenericNoConstraints(It.IsAny<GenericParameterIsIntOrString>()).Build().Setup().Returns("custom type matcher");
            Assert.AreEqual("custom type matcher", mockGenericNoConstraints.Object.InvokeGenericNoConstraints(new List<string>()));

            mockGenericNoConstraints.GenericNoConstraints(It.IsAny<It.IsSubtype<SubType1>>()).Build().Setup().Returns("sub type");
            Assert.AreEqual("sub type", mockGenericNoConstraints.Object.InvokeGenericNoConstraints(new Derivation1()));

            var mockRef = new ProtectedMock<MyProtected>();
            mockRef.Ref(ref It.Ref<int>.IsAny).Build().Setup().Returns("ref match");
            var refInt = 0;
            Assert.AreEqual("ref match", mockRef.Object.InvokeRef(ref refInt));//should also callback and demo 

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

        }

    }
}
