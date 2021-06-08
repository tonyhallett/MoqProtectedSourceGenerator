using System.IO;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class WriteFileWhenExecute : ISourceProvider
    {
        private static int ExecuteCount;
        private readonly string folder;

        public WriteFileWhenExecute(string folder)
        {
            this.folder = folder;
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            ExecuteCount++;
            File.WriteAllText(Path.Combine(folder, $"executed{ExecuteCount}.txt"), "");
        }
    }
}