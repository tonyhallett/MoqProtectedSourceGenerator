using Moq;

namespace MoqProtectedGenerated
{
    public interface ISetupVerify<TSetup,TSetupSequence>
    {
        TSetup Setup();

#pragma warning disable S125 // Sections of code should not be commented out
        //https://github.com/moq/moq4/pull/1174
        //TSetup InSequence(MockSequence mockSequence);
#pragma warning restore S125 // Sections of code should not be commented out

        void Verify(Times? times = null, string failMessage = null);

        TSetupSequence SetupSequence();
    }
}
