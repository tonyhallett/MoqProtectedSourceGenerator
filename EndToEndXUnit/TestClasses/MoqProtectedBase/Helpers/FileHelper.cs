using System.IO;

namespace EndToEndTests
{
    public static class FileHelper
    {
        public static void CopyFileToDirectory(string fromDirectory, string toDirectory, string fileName)
        {
            var file = Path.Combine(fromDirectory, fileName);
            var destination = Path.Combine(toDirectory, fileName);
            File.Copy(file, destination);
        }
    }
}
