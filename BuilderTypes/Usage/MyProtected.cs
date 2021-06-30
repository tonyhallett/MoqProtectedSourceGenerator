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

        public int GetGetSet()
        {
            return GetSet;
        }
        public void SetGetSet(int value)
        {
            GetSet = value;
        }

        protected abstract int GetOnly { get; }
        protected abstract int SetOnly { set; }

        protected abstract string this[int key1,string key2] { get;set; }
        public string GetIndex(int key1, string key2)
        {
            return this[key1, key2];
        }
        public void SetIndex(int key1,string key2,string value)
        {
            this[key1, key2] = value;
        }
    }

}
