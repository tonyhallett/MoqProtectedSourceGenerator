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
    }
}
