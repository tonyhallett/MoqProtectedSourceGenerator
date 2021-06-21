namespace MoqProtectedSourceGenerator
{
    public interface IBlockingSyntaxTreesVisitors : ISyntaxTreesVisitors
    {
        IVisitBlocker VisitBlocker { get; set; }
    }
}
