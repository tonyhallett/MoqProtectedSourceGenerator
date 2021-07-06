﻿using System.Collections.Generic;
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
        public PropertyExtensionMethods(
            IPropertyInvocationExtractor propertyInvocationExtractor,
            IArgumentInfoExtractor argumentInfoExtractor,
            IOptionsProvider optionsProvider
            )
        {
            this.propertyInvocationExtractor = propertyInvocationExtractor;
            this.argumentInfoExtractor = argumentInfoExtractor;
            this.optionsProvider = optionsProvider;
        }
        public List<Diagnostic> Diagnostics { get; } = new();
        public List<string> Namespaces { get; } = new() { "System.Reflection" };

        public List<(List<ArgumentInfo> argumentInfos, FileLocation fileLocation)> Setups { get; } = new();
        private List<ProtectedLikePropertyDetail> properties;
        private readonly IPropertyInvocationExtractor propertyInvocationExtractor;
        private readonly IArgumentInfoExtractor argumentInfoExtractor;
        private readonly IOptionsProvider optionsProvider;

        public void ExtensionInvocation(InvocationExpressionSyntax invocationExpression, string extensionName, SemanticModel semanticModel, AnalyzerConfigOptionsProvider analyzerConfigOptions)
        {
            var extraction = propertyInvocationExtractor.Extract(invocationExpression);
            if (extraction.Diagnostic != null)
            {
                Diagnostics.Add(extraction.Diagnostic);
            }
            if (!extraction.Success)
            {
                return;
            }

            //null for SetupProperty
            if(extraction.ArgumentInfoArguments != null)
            {
                var argumentExtraction = argumentInfoExtractor.Extract(extraction.ArgumentInfoArguments, semanticModel);
                if (argumentExtraction.Diagnostics.Count > 0)
                {
                    Diagnostics.AddRange(argumentExtraction.Diagnostics);
                }
                else
                {
                    var argumentInfos = argumentExtraction.ArgumentInfos;
                    Setups.Add((argumentInfos, extraction.FileLocation));

                }
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

        private (string fluentInterface, string fluentClass) GetNonIndexerFluentInterfaceAndClass(string mockedTypeName,string likeTypeName,PropertyGetSet propertyGetSet, string propertyType)
        {
            var interfaceGetSetSuffix = InterfaceGetSetSuffix(propertyGetSet);
            if(propertyType == "Task")
            {
                return (
                    $"INonIndexerFluent{interfaceGetSetSuffix}Task<{mockedTypeName}>",
                    $"NonIndexerFluentGetSetTask<{mockedTypeName}, {likeTypeName}>"
                );

            }else if(propertyType == "ValueTask")
            {
                return (
                    $"INonIndexerFluent{interfaceGetSetSuffix}ValueTask<{mockedTypeName}>",
                    $"NonIndexerFluentGetSetValueTask<{mockedTypeName},{likeTypeName}>"
                );

            }
            else if (propertyType.StartsWith("Task<"))
            {
                var resultType = TaskGenericHelper.ExtractResultType(propertyType);
                return (
                    $"INonIndexerFluent{interfaceGetSetSuffix}TaskResult<{mockedTypeName},{resultType}>",
                    $"NonIndexerFluentGetSetTaskResult<{mockedTypeName},{likeTypeName},{resultType}>"
                );


            }
            else if (propertyType.StartsWith("ValueTask<"))
            {
                var resultType = TaskGenericHelper.ExtractResultType(propertyType);
                return (
                    $"INonIndexerFluent{interfaceGetSetSuffix}ValueTaskResult<{mockedTypeName},{resultType}>",
                    $"NonIndexerFluentGetSetValueTaskResult<{mockedTypeName},{likeTypeName},{resultType}>"
                );
            }
            else
            {
                return (
                    $"INonIndexerFluent{interfaceGetSetSuffix}<{mockedTypeName},{propertyType}>",
                    $"NonIndexerFluentGetSet<{mockedTypeName},{likeTypeName},{propertyType}>"
                );
            }
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
            PropertyInfo property = typeof(MyProtectedLike).GetProperty(""{propertyName}"");
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

        private (string fluentInterface, string fluentClass) GetIndexerFluentInterfaceAndClass(string mockedTypeName, string likeTypeName, PropertyGetSet propertyGetSet, string propertyType,string types)
        {
            var interfaceGetSetSuffix = InterfaceGetSetSuffix(propertyGetSet);
            if (propertyType == "Task")
            {
                return (
                    $"IIndexerFluent{interfaceGetSetSuffix}Task<{mockedTypeName},  {types}>",
                    $"IndexerFluentGetSetTask<{mockedTypeName}, {likeTypeName}, {types}>"
                );

            }
            else if (propertyType == "ValueTask")
            {
                return (
                    $"IIndexerFluent{interfaceGetSetSuffix}ValueTask<{mockedTypeName},{types}>",
                    $"IndexerFluentGetSetValueTask<{mockedTypeName}, {likeTypeName}, {types}>"
                );

            }
            else if (propertyType.StartsWith("Task<"))
            {
                var resultType = TaskGenericHelper.ExtractResultType(propertyType);
                return (
                    $"IIndexerFluent{interfaceGetSetSuffix}TaskResult<{mockedTypeName}, {types}, {resultType}>",
                    $"IndexerFluentGetSetTaskResult<{mockedTypeName}, {likeTypeName}, {types}, {resultType}>"
                );


            }
            else if (propertyType.StartsWith("ValueTask<"))
            {
                var resultType = TaskGenericHelper.ExtractResultType(propertyType);
                return (
                    $"IIndexerFluent{interfaceGetSetSuffix}ValueTaskResult<{mockedTypeName}, {types}, {resultType}>",
                    $"IndexerFluentGetSetValueTaskResult<{mockedTypeName}, {likeTypeName}, {types}, {resultType}>"
                );
            }
            else
            {
                return (
                    $"IIndexerFluent{interfaceGetSetSuffix}<{mockedTypeName},  {types},{propertyType}>",
                    $"IndexerFluentGetSet<{mockedTypeName}, {likeTypeName}, {types}, {propertyType}>"
                );
            }
        }

        private (string types,string typeofs) TypeDetails(IEnumerable<string> types)
        {
            var typesStringBuilder = new StringBuilder();
            var typeOfsStringBuilder = new StringBuilder();
            bool first = true;
            foreach(var type in types)
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

        private (string names,string typesAndNames) ParameterDetails(ImmutableArray<IParameterSymbol> parameterSymbols)
        {
            var namesStringBuilder = new StringBuilder();
            var typesAndNamesStringBuilder = new StringBuilder();
            for(var i =0; i< parameterSymbols.Length; i++)
            {
                var parameterSymbol = parameterSymbols[i];
                var typeName = parameterSymbol.Type.Name;
                var parameterName = parameterSymbol.Name;
                if(i != 0)
                {
                    namesStringBuilder.Append(",");
                    typesAndNamesStringBuilder.Append(",");
                    
                }
                namesStringBuilder.Append(parameterName);
                typesAndNamesStringBuilder.Append($"{typeName} {parameterName}");
            }
            return (namesStringBuilder.ToString(),typesAndNamesStringBuilder.ToString());
        }

        private string GetExpressions(ImmutableArray<IParameterSymbol> parameterSymbols)
        {
            var statementStringBuilder = new StringBuilder();
            var expressionsListBuilder = new StringBuilder("            var expressions = new List<Expression>{");
            var count = 0;
            foreach(var parameter in parameterSymbols)
            {
                var parameterType = parameter.Type.Name;
                var parameterName = parameter.Name;
                statementStringBuilder.AppendLine(
                    $"            var expressionArg{count} = setupExpression.Create(({parameterType}){parameterName}, argumentInfos[{count}]);"
                );
                if(count != 0)
                {
                    expressionsListBuilder.Append(",");
                }
                expressionsListBuilder.Append($"expressionArg{count}");
                count++;

            }
            expressionsListBuilder.AppendLine("};");
            return statementStringBuilder.ToString() + expressionsListBuilder.ToString();
        }

        private string GetIndexerExtension(string mockedTypeName, string likeTypeName, PropertyGetSet propertyGetSet, string propertyType, IPropertySymbol propertySymbol, AnalyzerConfigOptionsProvider analyzerConfigOptions,int? suffix)
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
                    extensionMethod = GetIndexerExtension(mockedTypeName, likeTypeName, propertyGetSet, propertyType,propertySymbol, analyzerConfigOptions,requiresIndexerSuffix ? indexerCount : null);
                }
                else
                {
                    extensionMethod = GetNonIndexerExtension(mockedTypeName, likeTypeName, propertyGetSet, propertyType, propertyName);
                }

                stringBuilder.AppendLine(extensionMethod);

            }
            return stringBuilder.ToString();
        }

        public void Initialize(List<ProtectedLikePropertyDetail> Properties)
        {
            this.properties = Properties;
        }
    }
}
