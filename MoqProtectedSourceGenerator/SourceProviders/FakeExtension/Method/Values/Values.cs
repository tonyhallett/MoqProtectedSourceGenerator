using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class Values
    {

        public readonly List<ParameterAndProperty> ParameterAndProperty;
        public int Prop { get; set; }

        public Values(List<ParameterSyntax> parameters)
        {
            this.ParameterAndProperty = parameters.Select((p, i) =>
            {
                var name = p.Identifier.Text;
                var propertyName = StringHelpers.UppercaseFirst(name);
                var propertyType = p.Type.NormalizeWhitespace().ToFullString();
                var isOut = false;
                var wrappedType = OutType.GetWrappedType(propertyType);
                if (wrappedType != null)
                {
                    isOut = true;
                    propertyType = wrappedType;
                }
                return new ParameterAndProperty
                {
                    ParameterName = name,
                    PropertyName = propertyName,
                    PropertyType = propertyType,
                    IsOut = isOut
                };

            }).ToList();
        }

        public string GetClass()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var parameter in ParameterAndProperty)
            {
                sb.AppendLine(@$"
    public {parameter.PropertyType} {parameter.PropertyName} {{ get; set; }}
");
            }
            return @$"
private class Values{{
{sb}
}}
";
        }
        public string ObjectInitializer()
        {
            var stringBuilder = new StringBuilder();
            //use the aggregate from before
            foreach (var vp in ParameterAndProperty)
            {
                if (vp.IsOut)
                {
                    stringBuilder.AppendLine($"{vp.PropertyName} = {vp.ParameterName}.{OutType.WrappedProperty},");
                }
                else
                {
                    stringBuilder.AppendLine($"{vp.PropertyName} = {vp.ParameterName},");
                }
            }
            return $"{{{stringBuilder}}}";
        }
    }
}
