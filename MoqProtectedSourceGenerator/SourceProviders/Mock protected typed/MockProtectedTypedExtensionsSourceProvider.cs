using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MoqProtectedSourceGenerator.SourceProviders.Mock_protected_typed
{
    [Export(typeof(IExecutingVisitingSourceProvider))]
    [Export(typeof(IProtectedLikeCreationDependent))]
    public class MockProtectedTypedExtensionsSourceProvider : IExecutingVisitingSourceProvider, IProtectedLikeCreationDependent
    {
        private readonly IGlobalClassFromOptions globalClassFromOptions;
        private readonly List<IProtectedLike> protectedLikeInstances = new();
        private GeneratorExecutionContext context;

        [ImportingConstructor]
        public MockProtectedTypedExtensionsSourceProvider(
            IProtectedLikes protectedLikes,
            IGlobalClassFromOptions globalClassFromOptions
        )
        {
            this.globalClassFromOptions = globalClassFromOptions;
            protectedLikes.NewLikeEvent += ProtectedLikes_NewLikeEvent;
        }

        private void ProtectedLikes_NewLikeEvent(IProtectedLike protectedLike)
        {
            protectedLikeInstances.Add(protectedLike);
        }

        public void AddSource()
        {
            var usings = SourceHelper.JoinUsings(new List<string> { MoqUsings.Moq, MoqUsings.MoqProtected });
            var source = globalClassFromOptions.Get(usings, GetExtensionClass(), context.AnalyzerConfigOptions);
            context.AddSource("MockProtectedTypedExtensions.cs", source);
        }

        private string GetExtensionClass()
        {
            var stringBuilder = new StringBuilder();
            foreach (var protectedLike in protectedLikeInstances)
            {
                var mockType = protectedLike.MockedType.FullyQualifiedTypeName();
                var likeType = protectedLike.MinimallyUniqueLikeTypeName();
                stringBuilder.AppendLine($@"
    internal static IProtectedAsMock<{mockType},{likeType}> ProtectedTyped(this Mock<{mockType}> mock){{
        return mock.Protected().As<{likeType}>();              
    }}");
            }

            return @$"public static class MockProtectedTypedExtensions{{
{stringBuilder}
}}
";
        }

        public void Executing(GeneratorExecutionContext context)
        {
            protectedLikeInstances.Clear();
            this.context = context;
            // will provide option for generating or not
        }

        public TypeSyntax GetMockedType(SyntaxNode node)
        {
            // will use the option
            TypeSyntax mockedType = null;
            if (node is ObjectCreationExpressionSyntax objectCreationExpression)
            {
                var type = objectCreationExpression.Type;
                if (type is GenericNameSyntax genericName && genericName.Identifier.Text == "Mock")
                {
                    mockedType = genericName.TypeArgumentList.Arguments[0];
                }
            }
            return mockedType;
        }

        public void OnVisitSyntaxNode(SyntaxNode node)
        {

        }

        public void OnVisitTree(SyntaxTree syntaxTree)
        {

        }

    }

}
