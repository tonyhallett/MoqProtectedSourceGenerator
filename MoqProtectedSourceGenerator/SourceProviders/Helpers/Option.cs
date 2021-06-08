using System.Collections.Generic;

namespace MoqProtectedSourceGenerator
{
    public class Option<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }
        public bool IsObject { get; set; }

        public List<Finding> Findings { get; } = new List<Finding>();

    }


}
