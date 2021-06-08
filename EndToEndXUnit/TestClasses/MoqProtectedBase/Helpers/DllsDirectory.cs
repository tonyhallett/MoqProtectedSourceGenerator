using System.IO;
using System.Reflection;

namespace EndToEndTests
{
    public static class DllsDirectory
    {
        private static string path;
        public static string Path
        {
            get
            {
                if (path == null)
                {
                    var outputDirectory = new DirectoryInfo(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    path = System.IO.Path.Combine(outputDirectory.Parent.Parent.Parent.FullName, "dlls");
                }
                return path;
            }

        }
        public static void CopyDllToDirectory(string toDirectory, string dllName)
        {
            FileHelper.CopyFileToDirectory(Path, toDirectory, dllName);
        }

        public static string GetDllPath(string dllName)
        {
            return System.IO.Path.Combine(Path, dllName);
        }
    }
}
