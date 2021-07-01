using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public enum RefOutNone { None, Ref, Out};

    [Export(typeof(IDelegateProvider))]
    [Export(typeof(IExecutingVisitingSourceProvider))]
    public class DelegateSource : IDelegateProvider, IExecutingVisitingSourceProvider
    {
        private readonly List<string> delegates = new();
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
                return GetActionAndFuncDelegates(parameters,methodDeclaration.ReturnType);
            }
            return GetRefOutCallbackAndReturnDelegates(parameters, methodDeclaration.ReturnType);
        }

        private string GetRefOutCallbackAndReturnDelegates(SeparatedSyntaxList<ParameterSyntax> parameters, TypeSyntax returnType)
        {
            var callback = GetRefOutCallback(parameters);
            var returns = GetRefOutReturn(parameters, returnType);
            return $"{callback},{returns}";
        }

        private string GetActionAndFuncDelegates(SeparatedSyntaxList<ParameterSyntax> parameters,TypeSyntax returnType)
        {
            var returnTypeString = returnType.ToString();
            if(parameters.Count == 0)
            {
                return $"Action, Func<{returnTypeString}>";
            }

            var actionBuilder = new StringBuilder("Action<");
            var funcBuilder = new StringBuilder("Func<");
            for(var i = 0; i < parameters.Count; i++)
            {
                if (i != 0)
                {
                    actionBuilder.Append(",");
                    funcBuilder.Append(",");
                }
                var parameterType = parameters[i].Type.ToString();
                actionBuilder.Append(parameterType);
                funcBuilder.Append(parameterType);
            }

            actionBuilder.Append(">");
            funcBuilder.Append($",{returnTypeString}>");
            return $"{actionBuilder},{funcBuilder}";
            
        }

        private string GetCallbackDelegate(MethodDeclarationSyntax methodDeclaration)
        {
            var parameters = methodDeclaration.ParameterList.Parameters;
            if (!AnyOutRefParameters(parameters))
            {
                return GetActionDelegate(parameters);
            }
            return GetRefOutCallback(parameters);
        }

        private string GetTypeParameter(int index)
        {
            return $"T{index + 1}";
        }

        private string GetRefOutCallback(SeparatedSyntaxList<ParameterSyntax> parameters)
        {
            var prefixBuilder = new StringBuilder($"Del{parameters.Count}");
            var genericDelegateTypeArgsBuilder = new StringBuilder("<");
            var closedDelegateTypeArgsBuilder = new StringBuilder("<");
            var genericDelegateSignatureBuilder = new StringBuilder("(");
            for(var i = 0; i < parameters.Count; i++)
            {
                var parameter = parameters[i];
                var refOutNone = GetRefOutNone(parameter);
                DelegateName(prefixBuilder, i, refOutNone);
                if (i != 0)
                {
                    genericDelegateTypeArgsBuilder.Append(",");
                    closedDelegateTypeArgsBuilder.Append(",");
                    genericDelegateSignatureBuilder.Append(",");
                }
                genericDelegateTypeArgsBuilder.Append(GetTypeParameter(i));
                closedDelegateTypeArgsBuilder.Append(parameter.Type.ToString());
                genericDelegateSignatureBuilder.Append(GetParameter(i, refOutNone));
            }
            genericDelegateTypeArgsBuilder.Append(">");
            closedDelegateTypeArgsBuilder.Append(">");
            genericDelegateSignatureBuilder.Append(");");

            var prefix = prefixBuilder.ToString();
            
            var delegateType = $"    public delegate void {prefix}{genericDelegateTypeArgsBuilder}{genericDelegateSignatureBuilder}";
            if (!delegates.Contains(delegateType))
            {
                delegates.Add(delegateType);
            }
            var closedGeneric = $"{prefix}{closedDelegateTypeArgsBuilder}";
            return closedGeneric;
        }

        private string GetRefOutReturn(SeparatedSyntaxList<ParameterSyntax> parameters,TypeSyntax returnType)
        {
            var prefixBuilder = new StringBuilder($"DelReturn{parameters.Count}");
            var genericDelegateTypeArgsBuilder = new StringBuilder("<");
            var closedDelegateTypeArgsBuilder = new StringBuilder("<");
            var genericDelegateSignatureBuilder = new StringBuilder("(");
            var numParameters = parameters.Count;
            for (var i = 0; i < numParameters; i++)
            {
                var parameter = parameters[i];
                var refOutNone = GetRefOutNone(parameter);
                DelegateName(prefixBuilder, i, refOutNone);
                if (i != 0)
                {
                    genericDelegateTypeArgsBuilder.Append(",");
                    closedDelegateTypeArgsBuilder.Append(",");
                    genericDelegateSignatureBuilder.Append(",");
                }
                genericDelegateTypeArgsBuilder.Append(GetTypeParameter(i));
                closedDelegateTypeArgsBuilder.Append(parameter.Type.ToString());
                genericDelegateSignatureBuilder.Append(GetParameter(i, refOutNone));
            }
            genericDelegateTypeArgsBuilder.Append($",TResult>");
            closedDelegateTypeArgsBuilder.Append($",{returnType}>");
            genericDelegateSignatureBuilder.Append(");");

            var prefix = prefixBuilder.ToString();

            var delegateType = $"    public delegate TResult {prefix}{genericDelegateTypeArgsBuilder}{genericDelegateSignatureBuilder}";
            if (!delegates.Contains(delegateType))
            {
                delegates.Add(delegateType);
            }
            var closedGeneric = $"{prefix}{closedDelegateTypeArgsBuilder}";
            return closedGeneric;
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
            if(refOutNone == RefOutNone.Ref)
            {
                refOutPrefix = "ref ";
                namePrefix = "refArg";
            }else if(refOutNone == RefOutNone.Out)
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

            if (modifiers.Any(m => m.IsKind(SyntaxKind.OutKeyword))){
                refOutNone = RefOutNone.Out;
            } else if(modifiers.Any(m => m.IsKind(SyntaxKind.RefKeyword)))
            {
                refOutNone = RefOutNone.Ref;
            }
            return refOutNone;
        }

        private string GetActionDelegate(SeparatedSyntaxList<ParameterSyntax> parameters)
        {
            if (parameters.Count == 0)
            {
                return $"Action";
            }

            var actionBuilder = new StringBuilder("Action<");
            for (var i = 0; i < parameters.Count; i++)
            {
                if (i != 0)
                {
                    actionBuilder.Append(",");
                }
                var parameterType = parameters[i].Type.ToString();
                actionBuilder.Append(parameterType);
            }

            actionBuilder.Append(">");
            return actionBuilder.ToString();
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
            foreach(var @delegate in delegates)
            {
                delegatesSourceBuilder.AppendLine(@delegate);
            }
            context.AddSource("RefOutDelegates", SourceHelper.Create("", delegatesSourceBuilder.ToString()));
        }

        public void OnVisitTree(SyntaxTree syntaxTree)
        {
        }

        public void OnVisitSyntaxNode(SyntaxNode node)
        {
        }
    }

}
