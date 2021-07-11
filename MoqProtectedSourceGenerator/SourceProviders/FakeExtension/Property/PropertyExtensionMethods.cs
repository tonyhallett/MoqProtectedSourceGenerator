using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        private delegate (bool match, string fluentInterface, string fluentClass) IndexerFluentTypeProvider(string mockedTypeName, string likeTypeName, string propertyType, string types, string interfaceGetSetSuffix);
        private delegate (bool match, string fluentInterface, string fluentClass) NonIndexerFluentTypeProvider(string mockedTypeName, string likeTypeName, string propertyType, string interfaceGetSetSuffix);

        private readonly List<NonIndexerFluentTypeProvider> nonIndexerFluentTypesProviders;
        private readonly List<IndexerFluentTypeProvider> indexerFluentTypeProviders;
        private List<ProtectedLikePropertyDetail> properties;
        private readonly IPropertyInvocationExtractor propertyInvocationExtractor;
        private readonly IArgumentInfoExtractor argumentInfoExtractor;
        private readonly IOptionsProvider optionsProvider;

        public List<Diagnostic> Diagnostics { get; } = new();
        public List<string> Namespaces { get; } = new() { "System.Reflection" };
        public List<(List<ArgumentInfo> argumentInfos, FileLocation fileLocation)> Setups { get; } = new();

        public PropertyExtensionMethods(
            IPropertyInvocationExtractor propertyInvocationExtractor,
            IArgumentInfoExtractor argumentInfoExtractor,
            IOptionsProvider optionsProvider
            )
        {
            this.propertyInvocationExtractor = propertyInvocationExtractor;
            this.argumentInfoExtractor = argumentInfoExtractor;
            this.optionsProvider = optionsProvider;

            nonIndexerFluentTypesProviders = new()
            {
                TaskNonIndexerFluentTypesProvider,
                TaskResultNonIndexerFluentFluentTypesProvider,
                ValueTaskNonIndexerFluentFluentTypesProvider,
                ValueTaskResultNonIndexerFluentFluentTypesProvider,
                NonAsyncNonIndexerFluentFluentTypesProvider
            };
            indexerFluentTypeProviders = new()
            {
                TaskIndexerFluentFluentTypesProvider,
                TaskResultIndexerFluentFluentTypesProvider,
                ValueTaskIndexerFluentFluentTypesProvider,
                ValueTaskResultIndexerFluentFluentTypesProvider,
                NonAsyncIndexerFluentFluentTypesProvider
            };
        }

        private PropertyInvocationExtraction Extract(InvocationExpressionSyntax invocationExpression)
        {
            var extraction = propertyInvocationExtractor.Extract(invocationExpression);
            if (extraction.Diagnostic != null)
            {
                Diagnostics.Add(extraction.Diagnostic);
            }
            return extraction;
        }

        public void ExtensionInvocation(InvocationExpressionSyntax invocation, string extensionName, SemanticModel semanticModel, AnalyzerConfigOptionsProvider analyzerConfigOptions)
        {
            var extraction = Extract(invocation);

            // null for SetupProperty
            if (extraction.Success)
            {
                ExtractArguments(extraction.ArgumentInfoArguments, semanticModel, extraction.FileLocation);
            }

        }

        private void ExtractArguments(SeparatedSyntaxList<ArgumentSyntax> arguments, SemanticModel semanticModel, FileLocation fileLocation)
        {
            var argumentExtraction = argumentInfoExtractor.Extract(arguments, semanticModel);
            if (argumentExtraction.Diagnostics.Count > 0)
            {
                Diagnostics.AddRange(argumentExtraction.Diagnostics);
            }
            else
            {
                var argumentInfos = argumentExtraction.ArgumentInfos;
                Setups.Add((argumentInfos, fileLocation));

            }
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

        private string InterfaceGetSetSuffix(PropertyGetSet propertyGetSet)
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

            return suffix;
        }

        private (bool match, string fluentInterface, string fluentClass) TaskNonIndexerFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string interfaceGetSetSuffix)
        {
            if (propertyType == "Task")
            {
                return (
                    true,
                    $"INonIndexerFluent{interfaceGetSetSuffix}Task<{mockedTypeName}>",
                    $"NonIndexerFluentGetSetTask<{mockedTypeName}, {likeTypeName}>"
                );

            }
            return (false, null, null);
        }

        private (bool match, string fluentInterface, string fluentClass) TaskResultNonIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string interfaceGetSetSuffix)
        {
            if (propertyType.StartsWith("Task<"))
            {
                var resultType = TaskGenericHelper.ExtractResultType(propertyType);
                return (
                    true,
                    $"INonIndexerFluent{interfaceGetSetSuffix}TaskResult<{mockedTypeName},{resultType}>",
                    $"NonIndexerFluentGetSetTaskResult<{mockedTypeName},{likeTypeName},{resultType}>"
                );
            }
            return (false, null, null);
        }

        private (bool match, string fluentInterface, string fluentClass) ValueTaskNonIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string interfaceGetSetSuffix)
        {
            if (propertyType == "ValueTask")
            {
                return (
                    true,
                    $"INonIndexerFluent{interfaceGetSetSuffix}ValueTask<{mockedTypeName}>",
                    $"NonIndexerFluentGetSetValueTask<{mockedTypeName},{likeTypeName}>"
                );

            }
            return (false, null, null);
        }

        private (bool match, string fluentInterface, string fluentClass) ValueTaskResultNonIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string interfaceGetSetSuffix)
        {
            if (propertyType.StartsWith("ValueTask<"))
            {
                var resultType = TaskGenericHelper.ExtractResultType(propertyType);
                return (
                    true,
                    $"INonIndexerFluent{interfaceGetSetSuffix}ValueTaskResult<{mockedTypeName},{resultType}>",
                    $"NonIndexerFluentGetSetValueTaskResult<{mockedTypeName},{likeTypeName},{resultType}>"
                );
            }
            return (false, null, null);
        }

        private (bool match, string fluentInterface, string fluentClass) NonAsyncNonIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string interfaceGetSetSuffix)
        {
            return (
                true,
                $"INonIndexerFluent{interfaceGetSetSuffix}<{mockedTypeName},{propertyType}>",
                $"NonIndexerFluentGetSet<{mockedTypeName},{likeTypeName},{propertyType}>"
            );
        }

        private (string fluentInterface, string fluentClass) GetNonIndexerFluentInterfaceAndClass(string mockedTypeName, string likeTypeName, PropertyGetSet propertyGetSet, string propertyType)
        {
            var interfaceGetSetSuffix = InterfaceGetSetSuffix(propertyGetSet);
            foreach (var typesProvider in nonIndexerFluentTypesProviders)
            {
                var (match, fluentInterface, fluentClass) = typesProvider(mockedTypeName, likeTypeName, propertyType, interfaceGetSetSuffix);
                if (match)
                {
                    return (fluentInterface, fluentClass);
                }
            }
#pragma warning disable S112 // General exceptions should never be thrown
            throw new Exception("Non indexer fluent type provider not registered");
#pragma warning restore S112 // General exceptions should never be thrown
        }

        private string GetSetupProperty(PropertyGetSet propertyGetSet, string propertyName)
        {
            if (propertyGetSet == PropertyGetSet.Set)
            {
                return "null";
            }
            return $"like => like.{propertyName}";
        }

        private (string statements, string variable) GetSetupOrVerifyExpression(PropertyGetSet propertyGetSet, string likeTypeName, string propertyType, string propertyName)
        {
            if (propertyGetSet == PropertyGetSet.Get)
            {
                return ("", "null");
            }

            var statements = @$"        var likeParameter = Expression.Parameter(typeof({likeTypeName}));
        Expression<Action<{likeTypeName}>> GetSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber,List<Match> matches,{propertyType} propertyValue)
        {{
            PropertyInfo property = typeof({likeTypeName}).GetProperty(""{propertyName}"");
            MethodInfo setMethod = property.GetSetMethod();
            var argumentInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
            var setupExpression = new SetupExpressionArgument(matches);

            var expressionArg0 = setupExpression.Create(({propertyType})propertyValue, argumentInfos[0]);

            var body = Expression.Call(likeParameter, setMethod, expressionArg0);
            return Expression.Lambda<Action<{likeTypeName}>>(body, likeParameter);
        }}
";
            return (statements, "GetSetUpOrVerifyExpression");
        }

        private string GetNonIndexerExtension(string mockedTypeName, string likeTypeName, PropertyGetSet propertyGetSet, string propertyType, string propertyName)
        {
            var (statements, variable) = GetSetupOrVerifyExpression(propertyGetSet, likeTypeName, propertyType, propertyName);

            var (fluentInterface, fluentClass) = GetNonIndexerFluentInterfaceAndClass(mockedTypeName, likeTypeName, propertyGetSet, propertyType);

            return @$"    public static {fluentInterface} {propertyName}(this ProtectedMock<{mockedTypeName}> protectedMock){{
{statements}
        return new {fluentClass}(protectedMock, {variable}, {GetSetupProperty(propertyGetSet, propertyName)});
    }}
";
        }

        private (bool match, string fluentInterface, string fluentClass) TaskIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string types, string interfaceGetSetSuffix)
        {
            if (propertyType == "Task")
            {
                return (
                    true,
                    $"IIndexerFluent{interfaceGetSetSuffix}Task<{mockedTypeName},  {types}>",
                    $"IndexerFluentGetSetTask<{mockedTypeName}, {likeTypeName}, {types}>"
                );
            }
            return (false, null, null);
        }

        private (bool match, string fluentInterface, string fluentClass) ValueTaskIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string types, string interfaceGetSetSuffix)
        {
            if (propertyType == "ValueTask")
            {
                return (
                    true,
                    $"IIndexerFluent{interfaceGetSetSuffix}ValueTask<{mockedTypeName},{types}>",
                    $"IndexerFluentGetSetValueTask<{mockedTypeName}, {likeTypeName}, {types}>"
                );
            }
            return (false, null, null);
        }

        private (bool match, string fluentInterface, string fluentClass) TaskResultIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string types, string interfaceGetSetSuffix)
        {
            if (propertyType.StartsWith("Task<"))
            {
                var resultType = TaskGenericHelper.ExtractResultType(propertyType);
                return (
                    true,
                    $"IIndexerFluent{interfaceGetSetSuffix}TaskResult<{mockedTypeName}, {types}, {resultType}>",
                    $"IndexerFluentGetSetTaskResult<{mockedTypeName}, {likeTypeName}, {types}, {resultType}>"
                );
            }
            return (false, null, null);
        }

        private (bool match, string fluentInterface, string fluentClass) ValueTaskResultIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string types, string interfaceGetSetSuffix)
        {
            if (propertyType.StartsWith("ValueTask<"))
            {
                var resultType = TaskGenericHelper.ExtractResultType(propertyType);
                return (
                    true,
                    $"IIndexerFluent{interfaceGetSetSuffix}ValueTaskResult<{mockedTypeName}, {types}, {resultType}>",
                    $"IndexerFluentGetSetValueTaskResult<{mockedTypeName}, {likeTypeName}, {types}, {resultType}>"
                );
            }
            return (false, null, null);
        }

        private (bool match, string fluentInterface, string fluentClass) NonAsyncIndexerFluentFluentTypesProvider(string mockedTypeName, string likeTypeName, string propertyType, string types, string interfaceGetSetSuffix)
        {
            return (
                true,
                $"IIndexerFluent{interfaceGetSetSuffix}<{mockedTypeName},  {types},{propertyType}>",
                $"IndexerFluentGetSet<{mockedTypeName}, {likeTypeName}, {types}, {propertyType}>"
            );
        }

        private (string fluentInterface, string fluentClass) GetIndexerFluentInterfaceAndClass(string mockedTypeName, string likeTypeName, PropertyGetSet propertyGetSet, string propertyType, string types)
        {
            var interfaceGetSetSuffix = InterfaceGetSetSuffix(propertyGetSet);
            foreach (var indexerFluentTypeProvider in indexerFluentTypeProviders)
            {
                var (match, fluentInterface, fluentClass) = indexerFluentTypeProvider(mockedTypeName, likeTypeName, propertyType, types, interfaceGetSetSuffix);
                if (match)
                {
                    return (fluentInterface, fluentClass);
                }
            }
#pragma warning disable S112 // General exceptions should never be thrown
            throw new Exception("Indexer fluent type provider not registered");
#pragma warning restore S112 // General exceptions should never be thrown
        }

        private (string types, string typeofs) TypeDetails(IEnumerable<string> types)
        {
            var typesStringBuilder = new StringBuilder();
            var typeOfsStringBuilder = new StringBuilder();
            bool first = true;
            foreach (var type in types)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    typesStringBuilder.Append(",");
                    typeOfsStringBuilder.Append(",");
                }
                typesStringBuilder.Append(type);
                typeOfsStringBuilder.Append($"typeof({type})");
            }
            return (typesStringBuilder.ToString(), typeOfsStringBuilder.ToString());
        }

        private (string names, string typesAndNames) ParameterDetails(ImmutableArray<IParameterSymbol> parameterSymbols)
        {
            var namesStringBuilder = new StringBuilder();
            var typesAndNamesStringBuilder = new StringBuilder();
            for (var i = 0; i < parameterSymbols.Length; i++)
            {
                var parameterSymbol = parameterSymbols[i];
                var typeName = parameterSymbol.Type.Name;
                var parameterName = parameterSymbol.Name;
                if (i != 0)
                {
                    namesStringBuilder.Append(",");
                    typesAndNamesStringBuilder.Append(",");

                }
                namesStringBuilder.Append(parameterName);
                typesAndNamesStringBuilder.Append($"{typeName} {parameterName}");
            }
            return (namesStringBuilder.ToString(), typesAndNamesStringBuilder.ToString());
        }

        private string GetExpressions(ImmutableArray<IParameterSymbol> parameterSymbols)
        {
            var statementStringBuilder = new StringBuilder();
            var expressionsListBuilder = new StringBuilder("            var expressions = new List<Expression>{");
            var count = 0;
            foreach (var parameter in parameterSymbols)
            {
                var parameterType = parameter.Type.Name;
                var parameterName = parameter.Name;
                statementStringBuilder.AppendLine(
                    $"            var expressionArg{count} = setupExpression.Create(({parameterType}){parameterName}, argumentInfos[{count}]);"
                );
                if (count != 0)
                {
                    expressionsListBuilder.Append(",");
                }
                expressionsListBuilder.Append($"expressionArg{count}");
                count++;

            }
            expressionsListBuilder.AppendLine("};");
            return statementStringBuilder.ToString() + expressionsListBuilder.ToString();
        }

        private string GetIndexerExtension(string mockedTypeName, string likeTypeName, PropertyGetSet propertyGetSet, string propertyType, IPropertySymbol propertySymbol, AnalyzerConfigOptionsProvider analyzerConfigOptions, int? suffix)
        {
            var propertyName = GetIndexerName(propertySymbol);
            var extensionMethodName = "Item";
            if (optionsProvider.IndexerExtensionNameFromIndexerNameAttribute(analyzerConfigOptions))
            {
                extensionMethodName = propertyName;
            }
            if (suffix.HasValue)
            {
                extensionMethodName = extensionMethodName + "_" + suffix.Value;
            }
            var parameters = propertySymbol.Parameters;

            var (types, typeofs) = TypeDetails(parameters.Select(p => p.Type.Name));

            var (fluentInterface, fluentClass) = GetIndexerFluentInterfaceAndClass(mockedTypeName, likeTypeName, propertyGetSet, propertyType, types);

            var (names, typesAndNames) = ParameterDetails(parameters);
            var expressions = GetExpressions(parameters);
            return @$"
    public static {fluentInterface} {extensionMethodName}(this ProtectedMock<{mockedTypeName}> protectedMock)
    {{
        var likeParameter = Expression.Parameter(typeof({likeTypeName}));

        PropertyInfo indexerProperty = typeof({likeTypeName}).GetProperty(""{propertyName}"", typeof({propertyType}), new Type[] {{ {typeofs} }});
        MethodInfo indexerGet = indexerProperty.GetGetMethod();
        MethodInfo indexerSet = indexerProperty.GetSetMethod();
        
        Expression<T> GetSetUpOrVerifyExpressionBase<T>(string sourceFileInfo, int sourceLineNumber, List<Match> matches, {typesAndNames}, {propertyType} value, bool isSetter)
        {{
            var argumentInfos = Setups[GetKey(sourceFileInfo, sourceLineNumber)];
            var setupExpression = new SetupExpressionArgument(matches);

{expressions}
            
            MethodInfo indexerGetOrSet = indexerGet;
            if(isSetter)
            {{
                indexerGetOrSet = indexerSet;
                var valueExpression = setupExpression.Create(({propertyType})value, argumentInfos[{parameters.Length}]);
                expressions.Add(valueExpression);
            }}
            
            var body = Expression.Call(likeParameter, indexerGetOrSet, expressions);
            return Expression.Lambda<T>(body, likeParameter);
        }}

        Expression<Action<{likeTypeName}>> GetSetterSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber, List<Match> matches,{typesAndNames}, {propertyType} value)
        {{
            return GetSetUpOrVerifyExpressionBase<Action<{likeTypeName}>>(sourceFileInfo, sourceLineNumber, matches, {names}, value,true);
        }}

        Expression<Func<{likeTypeName},{propertyType}>> GetGetterSetUpOrVerifyExpression(string sourceFileInfo, int sourceLineNumber, List<Match> matches, {typesAndNames})
        {{
            return GetSetUpOrVerifyExpressionBase<Func<{likeTypeName}, {propertyType}>>(sourceFileInfo, sourceLineNumber, matches, {names}, default({propertyType}),false);
        }}

        return new {fluentClass}(protectedMock,GetGetterSetUpOrVerifyExpression,GetSetterSetUpOrVerifyExpression);
    }}
";
        }

        private string GetIndexerName(IPropertySymbol propertySymbol)
        {
            var indexerNameAttribute = propertySymbol.GetAttributes().FirstOrDefault(a => a.AttributeClass != null && a.AttributeClass.FullyQualifiedTypeName() == "System.Runtime.CompilerServices.IndexerNameAttribute");
            if (indexerNameAttribute != null)
            {
                var indexerNameArgument = indexerNameAttribute.ConstructorArguments[0];
                return (string)indexerNameArgument.Value;
            }


            return "Item";
        }

        public string GetExtensionMethods(string mockedTypeName, string likeTypeName, AnalyzerConfigOptionsProvider analyzerConfigOptions)
        {
            var stringBuilder = new StringBuilder();
            var requiresIndexerSuffix = properties.Count(p => p.Symbol.IsIndexer) > 1;
            var indexerCount = 0;
            foreach (var property in properties)
            {
                var propertySymbol = property.Symbol;

                var propertyName = propertySymbol.Name;
                var propertyType = property.Declaration.Type.ToString();
                var propertyGetSet = GetGetSet(propertySymbol);
                string extensionMethod;
                if (propertySymbol.IsIndexer)
                {
                    indexerCount++;
                    extensionMethod = GetIndexerExtension(mockedTypeName, likeTypeName, propertyGetSet, propertyType, propertySymbol, analyzerConfigOptions, requiresIndexerSuffix ? indexerCount : null);
                }
                else
                {
                    extensionMethod = GetNonIndexerExtension(mockedTypeName, likeTypeName, propertyGetSet, propertyType, propertyName);
                }

                stringBuilder.AppendLine(extensionMethod);

            }
            return stringBuilder.ToString();
        }

        public void Initialize(List<ProtectedLikePropertyDetail> properties)
        {
            this.properties = properties;
        }
    }
}
