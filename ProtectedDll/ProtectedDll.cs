using System;
using IFace;
using OtherNamespace;

namespace ProtectedDll
{
    

    public abstract class DllProtected
    {
        protected abstract void ProtectedMethod(Other v1, string v2);

        protected abstract void ProtectedGenericMethod<T>(T t1,T t2) where T:IInterface;
        public void CallProtectedMethod(Other v1, string v2)
        {
            ProtectedMethod(v1, v2);
        }
        public void CallProtectedGenericMethod<T>(T t1,T t2) where T : IInterface
        {
             ProtectedGenericMethod<T>(t1, t2);
        }

        protected abstract int SomeProperty { get; }
        //later will add compiler
        protected abstract int this[int index1,string index2] { get;set; }
    }
}
