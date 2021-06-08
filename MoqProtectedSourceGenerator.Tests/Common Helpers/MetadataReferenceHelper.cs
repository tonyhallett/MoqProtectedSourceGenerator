using System.Reflection;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator.Tests
{
    public static class MetadataReferenceHelper
    {
        public static MetadataReference CreateFromAssemblyLoad(string assemblyName)
        {
            return MetadataReference.CreateFromFile(Assembly.Load(assemblyName).Location);
        }
    }
}
