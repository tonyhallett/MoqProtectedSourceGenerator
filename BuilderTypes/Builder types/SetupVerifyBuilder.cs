using System;
using Moq;


namespace MoqProtectedGenerated
{
    public class SetupVerifyBuilder<TSetup> : ISetupVerifyBuilder<TSetup>, ISetupVerify<TSetup>
    {
        private readonly Func<string, int, TSetup> setup;
        private readonly Action<string, int, Times?, string> verify;
        private string sourceFilePath;
        private int sourceLineNumber;

        public SetupVerifyBuilder(Func<string, int, TSetup> setup, Action<string, int, Times?, string> verify)
        {
            this.setup = setup;
            this.verify = verify;
        }

        public ISetupVerify<TSetup> Build([System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            this.sourceFilePath = sourceFilePath;
            this.sourceLineNumber = sourceLineNumber;
            return this;
        }

        public TSetup Setup()
        {
            return setup(sourceFilePath, sourceLineNumber);
        }

        public void Verify(Times? times = null, string failMessage = null)
        {
            verify(sourceFilePath, sourceLineNumber, times, failMessage);
        }
    }
}
