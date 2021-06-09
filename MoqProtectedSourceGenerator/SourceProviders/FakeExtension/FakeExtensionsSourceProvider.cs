using System.Collections.Generic;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator
{
    public class FakeExtensionsSourceProvider : ISyntaxSourceProvider
    {
        private readonly ProtectedLikes protectedLikes;
#pragma warning disable RS1024 // Compare symbols correctly - false positive waiting for version 3.3 https://github.com/dotnet/roslyn-analyzers/issues/4845
        private readonly Dictionary<ITypeSymbol, FakeExtension> fakeExtensions = new(SymbolEqualityComparer.Default);
#pragma warning restore RS1024 // Compare symbols correctly
        private readonly FakeExtensionVisitor fakeExtensionVisitor = new();

        public FakeExtensionsSourceProvider(ProtectedLikes protectedLikes)
        {
            this.protectedLikes = protectedLikes;
            this.protectedLikes.NewLikeEvent += ProtectedLikes_NewLikeEvent;
        }

        private void ProtectedLikes_NewLikeEvent(ProtectedLike protectedLike)
        {
            fakeExtensions.Add(protectedLike.MockedType, new FakeExtension(protectedLike));
        }

        private void AddSetupOrVerify(FakeExtensionSetupOrVerify fakeExtensionSetupOrVerify)
        {
            var fakeExtension = fakeExtensions[fakeExtensionSetupOrVerify.MockedType];
            fakeExtension.AddSetupOrVerify(fakeExtensionSetupOrVerify.IsSetup, fakeExtensionSetupOrVerify.ExtensionMethod, fakeExtensionSetupOrVerify.FileLocation);
        }

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (protectedLikes.ProtectedLikesList.Count > 0)
            {
                var node = context.Node;
                if (node is InvocationExpressionSyntax invocation)
                {
                    var result = fakeExtensionVisitor.Visit(invocation, context.SemanticModel);
                    if (result != null && IsProtectedLikeExtensionMethod(result.ExtensionMethod, result.MockedType))
                    {
                        AddSetupOrVerify(result);
                    }
                }
            }
        }

        private bool IsProtectedLikeExtensionMethod(ExtensionMethod extensionMethod, ITypeSymbol mockedType)
        {
            return fakeExtensions[mockedType].IsExtensionMethod(extensionMethod);
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            if (fakeExtensions.Count > 0)
            {
                foreach (var fakeExtension in fakeExtensions.Values)
                {
                    fakeExtension.AddSource(context);
                }
                AddCommon(context);
            }

        }

        private void AddCommon(GeneratorExecutionContext context)
        {
            AddVoidMethodTypes(context);
        }

        private void AddVoidMethodTypes(GeneratorExecutionContext context)
        {
            Dictionary<string, string> builderTypes = ManifestResourceStringReader.Read("BuilderTypes");
            foreach(var kvp in builderTypes)
            {
                context.AddSource($"{kvp.Key}.cs", kvp.Value);
            }
        }

    }
}
