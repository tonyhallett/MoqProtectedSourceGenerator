using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{
    [Export(typeof(IPropertyExtensionMethods))]
    public class PropertyExtensionMethods : IPropertyExtensionMethods
    {
        public List<Diagnostic> Diagnostics { get; } = new();

        public List<(List<ParameterInfo> parameterInfos, FileLocation fileLocation)> Setups { get; } = new();
        private List<ProtectedLikePropertyDetail> properties;

        public void ExtensionInvocation(InvocationExpressionSyntax invocation, string extensionName, SemanticModel semanticModel, AnalyzerConfigOptionsProvider analyzerConfigOptions)
        {

        }

        private PropertyGetSet GetGetSet(IPropertySymbol propertySymbol)
        {
            var propertyGetSet = PropertyGetSet.GetSet;
            if (propertySymbol.IsReadOnly)
            {
                propertyGetSet = PropertyGetSet.Get;
            }
            else if (propertySymbol.IsWriteOnly)
            {
                propertyGetSet = PropertyGetSet.Set;
            }
            return propertyGetSet;
        }

        private string GetNonIndexerFluentInterface(PropertyGetSet propertyGetSet)
        {
            var suffix = "GetSet";
            switch (propertyGetSet)
            {
                case PropertyGetSet.Get:
                    suffix = "Get";
                    break;
                case PropertyGetSet.Set:
                    suffix = "Set";
                    break;
            }

            return $"INonIndexerFluent{suffix}";
        }

        private string GetSetupProperty(PropertyGetSet propertyGetSet, string propertyName)
        {
            if (propertyGetSet == PropertyGetSet.Set)
            {
                return "null";
            }
            return $"like => like.{propertyName}";
        }

        private (string statements, string variable) GetSetupOrVerifyExpression(PropertyGetSet propertyGetSet, string likeTypeName, string propertyType, string propertName)
        {
            if (propertyGetSet == PropertyGetSet.Get)
            {
                return ("", "null");
            }

            var statements = @$"        var likeParameter = Expression.Parameter(typeof({likeTypeName}));
        Expression<Action<{likeTypeName}>> GetSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber,List<Match> matches,{propertyType} propertyValue)
        {{
            var parameterInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
            var setupExpression = new SetupExpressionArgument(matches);

            var expressionArg0 = setupExpression.Create(({propertyType})propertyValue, parameterInfos[0]);

            var body = Expression.Assign(Expression.Property(likeParameter, ""{propertName}""), expressionArg0);
            return Expression.Lambda<Action<{likeTypeName}>>(body, likeParameter);
        }}
";
            return (statements, "GetSetUpOrVerifyExpression");
        }

        private string GetNonIndexerExtension(string mockedTypeName, string likeTypeName, PropertyGetSet propertyGetSet, string propertyType, string propertyName)
        {
            var (statements, variable) = GetSetupOrVerifyExpression(propertyGetSet, likeTypeName, propertyType, propertyName);
            return @$"    public static {GetNonIndexerFluentInterface(propertyGetSet)}<{mockedTypeName},{propertyType}> {propertyName}(this ProtectedMock<{mockedTypeName}> protectedMock){{
{statements}
        return new NonIndexerFluentGetSet<{mockedTypeName}, {likeTypeName}, {propertyType}>(protectedMock, {variable}, {GetSetupProperty(propertyGetSet, propertyName)});
    }}
";
        }

        private string GetIndexerName(IPropertySymbol propertySymbol, AnalyzerConfigOptionsProvider analyzerConfigOptions)
        {
            var useCompilerAttribute = true;
            if (useCompilerAttribute)
            {
                var indexerNameAttribute = propertySymbol.GetAttributes().FirstOrDefault(a => a.AttributeClass != null && a.AttributeClass.FullyQualifiedTypeName() == "System.Runtime.CompilerServices.IndexerNameAttribute");
                if (indexerNameAttribute != null)
                {
                    var indexerNameArgument = indexerNameAttribute.ConstructorArguments[0];
                    return (string)indexerNameArgument.Value;
                }
            }

            return "Item";
        }

        public string GetExtensionMethods(string mockedTypeName, string likeTypeName, AnalyzerConfigOptionsProvider analyzerConfigOptions)
        {
            var stringBuilder = new StringBuilder();
            foreach (var property in properties)
            {
                var propertySymbol = property.Symbol;

                var propertyName = propertySymbol.Name;
                var propertyGetSet = GetGetSet(propertySymbol);
                var extensionMethod = "";
                if (propertySymbol.IsIndexer)
                {
                    propertyName = GetIndexerName(propertySymbol, analyzerConfigOptions);
                    //todo
                }
                else
                {
                    var propertyType = propertySymbol.Type.Name;
                    extensionMethod = GetNonIndexerExtension(mockedTypeName, likeTypeName, propertyGetSet, propertyType, propertyName);
                    stringBuilder.AppendLine(extensionMethod);
                }

            }
            return stringBuilder.ToString();
        }

        public void Initialize(List<ProtectedLikePropertyDetail> Properties)
        {
            this.properties = Properties;
        }
    }
}
