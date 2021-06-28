namespace MoqProtectedGenerated
{
    public interface MyProtectedLike
    {
        int AbstractMethodWithReturn();
        void AbstractMethod();
        void AbstractMethodArgs(int value);
        int GetSet { get; set; }
        int GetOnly { get; }
        int SetOnly { set; }
        string this[int key1, string key2] { get; set; }
    }

}
