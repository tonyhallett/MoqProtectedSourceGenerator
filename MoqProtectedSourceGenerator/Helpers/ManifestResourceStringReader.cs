using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;

namespace MoqProtectedSourceGenerator
{
    public static class ManifestResourceStringReader
    {
        public static Dictionary<string, string> Read(string resourceName)
        {
            using var manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            using var reader = new ResourceReader(manifestResourceStream);
            IDictionaryEnumerator dict = reader.GetEnumerator();
            Dictionary<string, string> resources = new Dictionary<string, string>();
            while (dict.MoveNext())
            {
                resources.Add(dict.Key as string, dict.Value as string);
            }
            return resources;
        }
    }
}
