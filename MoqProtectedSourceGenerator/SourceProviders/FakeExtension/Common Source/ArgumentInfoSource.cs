using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IProtectedLikeExtensionSource))]
    [Export(typeof(IExecuteAware))]
    public class ArgumentInfoSource : CommonSingleSource, IProtectedLikeExtensionSource
    {
        protected override List<string> Usings => new()
        {
            "using System.Linq.Expressions;"
        };
        protected override string HintName => "ArgumentInfo";
        protected override string Source =>
@"    public enum ArgumentType { UseValue, Match, Out, RefAny }

    public class ArgumentInfo
    {
        public ArgumentType Type { get; set; }
        public Expression RefAny { get; set; }
    }
";

    }
}
