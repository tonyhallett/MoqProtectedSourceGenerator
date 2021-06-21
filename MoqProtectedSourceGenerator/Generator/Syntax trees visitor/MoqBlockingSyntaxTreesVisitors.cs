using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IMoqBlockingSyntaxTreesVisitors))]
    public class MoqBlockingSyntaxTreesVisitors : BlockingSyntaxTreesVisitors, IMoqBlockingSyntaxTreesVisitors
    {
        [ImportingConstructor]
        public MoqBlockingSyntaxTreesVisitors(MoqBlocker moqBlocker)
        {
            this.VisitBlocker = moqBlocker;
        }
    }
}
