namespace MoqProtectedSourceGenerator
{
    public interface ILogger
    {
        void Log(string message, string caller = "");
    }
}