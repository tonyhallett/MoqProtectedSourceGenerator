using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class ProtectedLikeExtensionClasses : IProtectedLikeExtensions
    {
        private readonly List<IFakeExtensionMethod> fakeExtensionMethods;
        public ProtectedLikeExtensionClasses(IProtectedLike protectedLike, IMethodFakeExtensionFactory methodFakeExtensionFactory)
        {
            //foreach(var property in protectedLike.Properties)
            //{
            //    //todo
            //}
            fakeExtensionMethods = protectedLike.Methods.Select(m => methodFakeExtensionFactory.Create(protectedLike.LikeTypeName, protectedLike.MockedTypeName, protectedLike.MockedTypeNamespace, m)).ToList();
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            foreach (var fakeExtensionMethod in fakeExtensionMethods)
            {
                fakeExtensionMethod.AddSource(context);
            }
        }

        public void ExtensionInvocation(Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax invocation, string extensionName, SemanticModel semanticModel)
        {
            foreach (var fakeExtensionMethod in fakeExtensionMethods)
            {
                var matchingExtensionMethod = fakeExtensionMethod.ExtensionInvocation(invocation, extensionName, semanticModel);
                if (matchingExtensionMethod)
                {
                    break;
                }
            }
        }

    }
}
