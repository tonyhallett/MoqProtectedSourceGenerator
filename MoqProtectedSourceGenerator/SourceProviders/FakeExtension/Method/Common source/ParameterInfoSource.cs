using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IParameterInfoSource))]
    [Export(typeof(IExecuteAware))]
    public class ParameterInfoSource : CommonSingleSource, IParameterInfoSource
    {
        protected override List<string> Usings => new()
        {
            "using System.Linq.Expressions;"
        };
        protected override string HintName => "ParameterInfo";
        protected override string Source =>
@"    public enum ParameterType { UseValue, Match, Out, RefAny }

    public class ParameterInfo
    {
        public ParameterType Type { get; set; }
        public Expression RefAny { get; set; }
    }
";

    }
}
