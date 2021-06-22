using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class MethodStepContext : IStepContext
    {
        public FileLocation FileLocation { get; set; }
        public StepContextState State { get; set; }
        private Diagnostic diagnostic;
        public Diagnostic Diagnostic
        {
            get { return diagnostic; }
            set
            {
                State = StepContextState.Failed;
                diagnostic = value;
            }
        }
    }
}
