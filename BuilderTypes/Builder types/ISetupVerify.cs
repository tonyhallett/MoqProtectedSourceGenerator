using Moq;


namespace MoqProtectedGenerated
{
    public interface ISetupVerify<TSetup>
    {
        TSetup Setup();
        void Verify(Times? times = null, string failMessage = null);
    }
}
