namespace ANamespace
{
    public abstract class MyProtected
    {
        protected abstract int AbstractMethodWithReturn();
        protected abstract void AbstractMethod();
        public void InvokeAbstractMethod()
        {
            AbstractMethod();
        }
        protected abstract void AbstractMethodArgs(int value);
        public void InvokeAbstractMethodArgs(int value)
        {
            AbstractMethodArgs(value);
        }

        protected abstract int GetSet { get; set; }
        protected abstract int GetOnly { get; }
        protected abstract int SetOnly { set; }

        protected abstract string this[int key1,float key2] { get;set; }

    }

}
