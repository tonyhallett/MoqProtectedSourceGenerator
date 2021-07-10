using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public enum RefOutNone { None, Ref, Out };

    [Export(typeof(IDelegateProvider))]
    [Export(typeof(IExecutingVisitingSourceProvider))]
    public class DelegateSource : IDelegateProvider, IExecutingVisitingSourceProvider
    {
        private readonly List<string> delegates = new();
        private const string TResult = "TResult";
        private const string Func = "Func";
        private const string Action = "Action";
        private GeneratorExecutionContext context;

        public string GetDelegates(MethodDeclarationSyntax methodDeclaration)
        {
            if (methodDeclaration.ReturnTypeIsVoid())
            {
                return GetCallbackDelegate(methodDeclaration);
            }
            else
            {
                return GetCallbackAndReturnDelegates(methodDeclaration);
            }
        }

        private string GetCallbackAndReturnDelegates(MethodDeclarationSyntax methodDeclaration)
        {
            var parameters = methodDeclaration.ParameterList.Parameters;
            if (!AnyOutRefParameters(parameters))
            {
                return GetActionAndFuncDelegates(parameters, methodDeclaration.ReturnType);
            }
            return GetRefOutCallbackAndReturnDelegates(parameters, methodDeclaration.ReturnType);
        }

        private string GetCallbackDelegate(MethodDeclarationSyntax methodDeclaration)
        {
            var parameters = methodDeclaration.ParameterList.Parameters;
            if (!AnyOutRefParameters(parameters))
            {
                return GetActionDelegate(parameters);
            }
            return GetRefOutCallbackOrReturn(parameters);
        }

        private string GetRefOutCallbackAndReturnDelegates(SeparatedSyntaxList<ParameterSyntax> parameters, TypeSyntax returnType)
        {
            var callback = GetRefOutCallbackOrReturn(parameters);
            var returns = GetRefOutCallbackOrReturn(parameters, returnType);
            return $"{callback},{returns}";
        }

        private void CommaDelimit(bool isFirst, params StringBuilder[] stringBuilders)
        {
            if (!isFirst)
            {
                foreach (var stringBuilder in stringBuilders)
                {
                    stringBuilder.Append(",");
                }
            }
        }

        private void BuildFromParameters(
            SeparatedSyntaxList<ParameterSyntax> parameters,
            StringBuilder prefixBuilder,
            StringBuilder genericDelegateTypeArgsBuilder,
            StringBuilder closedDelegateTypeArgsBuilder,
            StringBuilder genericDelegateSignatureBuilder)
        {
            var numParameters = parameters.Count;
            for (var i = 0; i < numParameters; i++)
            {
                var parameter = parameters[i];
                var refOutNone = GetRefOutNone(parameter);
                DelegateName(prefixBuilder, i, refOutNone);
                CommaDelimit(i == 0, genericDelegateSignatureBuilder, genericDelegateTypeArgsBuilder, closedDelegateTypeArgsBuilder);

                genericDelegateTypeArgsBuilder.Append(GetTypeParameter(i));
                closedDelegateTypeArgsBuilder.Append(parameter.Type.ToString());
                genericDelegateSignatureBuilder.Append(GetParameter(i, refOutNone));
            }
        }

        private string DelegateReturnType(bool isReturn)
        {
            return isReturn ? TResult : "void";
        }

        private string GetRefOutCallbackOrReturn(SeparatedSyntaxList<ParameterSyntax> parameters, TypeSyntax returnType = null)
        {
            var isReturn = returnType != null;
            var delegateNamePrefix = isReturn ? "Return" : "";
            var prefixBuilder = new StringBuilder($"Del{delegateNamePrefix}{parameters.Count}");
            var genericDelegateTypeArgsBuilder = new StringBuilder("<");
            var closedDelegateTypeArgsBuilder = new StringBuilder("<");
            var genericDelegateSignatureBuilder = new StringBuilder("(");

            BuildFromParameters(parameters, prefixBuilder, genericDelegateTypeArgsBuilder, closedDelegateTypeArgsBuilder, genericDelegateSignatureBuilder);

            var typeSuffix = isReturn ? $",{TResult}" : "";
            genericDelegateTypeArgsBuilder.Append($"{typeSuffix}>");

            var closedTypeSuffix = isReturn ? $",{returnType}" : "";
            closedDelegateTypeArgsBuilder.Append($"{closedTypeSuffix}>");

            genericDelegateSignatureBuilder.Append(");");

            var prefix = prefixBuilder.ToString();
            var delegateReturnType = DelegateReturnType(isReturn);
            var delegateType = $"    public delegate {delegateReturnType} {prefix}{genericDelegateTypeArgsBuilder}{genericDelegateSignatureBuilder}";
            AddDelegateType(delegateType);
            var closedGeneric = $"{prefix}{closedDelegateTypeArgsBuilder}";
            return closedGeneric;
        }

        private void AddDelegateType(string delegateType)
        {
            if (!delegates.Contains(delegateType))
            {
                delegates.Add(delegateType);
            }
        }

        private string GetTypeParameter(int index)
        {
            return $"T{index + 1}";
        }

        private void DelegateName(StringBuilder nameBuilder, int index, RefOutNone refOutNone)
        {
            switch (refOutNone)
            {
                case RefOutNone.None:
                    break;
                case RefOutNone.Out:
                    nameBuilder.Append($"_Out{index + 1}");
                    break;
                case RefOutNone.Ref:
                    nameBuilder.Append($"_Ref{index + 1}");
                    break;
            }
        }

        private string GetParameter(int index, RefOutNone refOutNone)
        {
            var refOutPrefix = "";
            var namePrefix = "arg";
            if (refOutNone == RefOutNone.Ref)
            {
                refOutPrefix = "ref ";
                namePrefix = "refArg";
            }
            else if (refOutNone == RefOutNone.Out)
            {
                refOutPrefix = "out ";
                namePrefix = "outArg";
            }
            return $"{refOutPrefix}{GetTypeParameter(index)} {namePrefix}{index + 1}";
        }

        private RefOutNone GetRefOutNone(ParameterSyntax parameter)
        {
            RefOutNone refOutNone = RefOutNone.None;
            var modifiers = parameter.Modifiers;

            if (modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword)))
            {
                refOutNone = RefOutNone.Out;
            }
            else if (modifiers.Any(m => m.IsKind(SyntaxKind.RefKeyword)))
            {
                refOutNone = RefOutNone.Ref;
            }
            return refOutNone;
        }

        private string GetActionAndFuncDelegates(SeparatedSyntaxList<ParameterSyntax> parameters, TypeSyntax returnType)
        {
            var returnTypeString = returnType.ToString();
            var action = GetActionDelegate(parameters);
            var func = GetFunc(parameters, returnTypeString);
            var actionAndFuncDelegates = $"{action},{func}";
            if (returnTypeString.StartsWith("ValueTask<") || returnTypeString.StartsWith("Task<"))
            {
                actionAndFuncDelegates += $", {GetFunc(parameters, TaskGenericHelper.ExtractResultType(returnTypeString))}";
            }
            return actionAndFuncDelegates;
        }

        private string GetFunc(SeparatedSyntaxList<ParameterSyntax> parameters, string returnType)
        {
            var func = $"{Func}<{returnType}>";
            if (parameters.Count > 0)
            {
                func = GetFuncOrActionWithParameters(parameters, Func, $",{returnType}");
            }
            return func;
        }

        private string GetFuncOrActionWithParameters(SeparatedSyntaxList<ParameterSyntax> parameters, string delegateName, string beforeClosingBracket = "")
        {
            var actionBuilder = new StringBuilder($"{delegateName}<");
            for (var i = 0; i < parameters.Count; i++)
            {
                if (i != 0)
                {
                    actionBuilder.Append(",");
                }
                var parameterType = parameters[i].Type.ToString();
                actionBuilder.Append(parameterType);
            }

            actionBuilder.Append($"{beforeClosingBracket}>");
            return actionBuilder.ToString();
        }

        private string GetActionDelegate(SeparatedSyntaxList<ParameterSyntax> parameters)
        {
            if (parameters.Count == 0)
            {
                return Action;
            }

            return GetFuncOrActionWithParameters(parameters, Action);
        }

        private bool AnyOutRefParameters(SeparatedSyntaxList<ParameterSyntax> parameters)
        {
            return parameters.Any(p =>
            {
                var modifiers = p.Modifiers;
                return modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword) || m.IsKind(SyntaxKind.RefKeyword));
            });
        }

        public void Executing(GeneratorExecutionContext context)
        {
            this.context = context;
            delegates.Clear();
        }

        public void AddSource()
        {
            var delegatesSourceBuilder = new StringBuilder();
            foreach (var @delegate in delegates)
            {
                delegatesSourceBuilder.AppendLine(@delegate);
            }
            context.AddSource("RefOutDelegates", SourceHelper.Create("", delegatesSourceBuilder.ToString()));
        }

        public void OnVisitTree(SyntaxTree syntaxTree)
        {
            // Method intentionally left empty.
        }

        public void OnVisitSyntaxNode(SyntaxNode node)
        {
            // Method intentionally left empty.
        }
    }

}
