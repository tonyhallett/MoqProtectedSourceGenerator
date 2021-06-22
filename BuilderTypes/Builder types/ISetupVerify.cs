using Moq;


namespace MoqProtectedGenerated
{
    public interface ISetupVerify<TSetup,TSetupSequence>
    {
        TSetup Setup();
        TSetupSequence SetupSequence();
        void Verify(Times? times = null, string failMessage = null);
    }
}
