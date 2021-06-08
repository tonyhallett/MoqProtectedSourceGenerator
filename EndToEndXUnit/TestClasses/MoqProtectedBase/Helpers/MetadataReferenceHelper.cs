using System.Reflection;
using Microsoft.CodeAnalysis;

namespace EndToEndTests
{
    public static class MetadataReferenceHelper
    {
        public static MetadataReference CreateFromAssemblyLoad(string assemblyName)
        {
            return MetadataReference.CreateFromFile(Assembly.Load(assemblyName).Location);
        }
    }
}
