using Microsoft.CodeAnalysis;

namespace EndToEndTests
{
    public static class DynamicKeywordMetadataReference
    {
        private static readonly MetadataReference metadataReference = MetadataReferenceHelper.CreateFromAssemblyLoad("Microsoft.CSharp");
        public static MetadataReference MetadataReference => metadataReference;
        public static MetadataReference[] Single => new MetadataReference[] { MetadataReference };
    }
}
