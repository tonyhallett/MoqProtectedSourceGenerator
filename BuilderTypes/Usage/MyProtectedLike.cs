namespace MoqProtectedGenerated
{
    internal interface MyProtectedLike
    {
        int AbstractMethodWithReturn();
        void AbstractMethod();
        void AbstractMethodArgs(int value);
        int GetSet { get; set; }
        int GetOnly { get; }
        int SetOnly { set; }
        string this[int key1, float key2] { get; set; }
    }

}
