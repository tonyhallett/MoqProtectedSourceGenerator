namespace ProtectedDll
{
    public abstract class Duplicate
    {
        protected abstract string Dupe(int value);
        public string Invoke(int value)
        {
            return Dupe(value);
        }
    }
}
