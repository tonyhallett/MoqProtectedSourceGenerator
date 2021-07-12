namespace EndToEndTests
{
    public static class TestSource
    {
        public static string ProtectedInSource(string myProtectedMembers, string testSource, string additionalTypes = "", string additionalUsings = "")
        {
            return @$"
using System;
using Moq;
using NUnit.Framework;
using MoqProtectedTyped;
{additionalUsings}

namespace ClassLibrary1
{{
{additionalTypes}
    public abstract class MyProtected
    {{
{myProtectedMembers}
    }}

    public class ExpectedException : Exception {{ }}

    public class Test
    {{
        [Test]
        public void Generate()
        {{
            var mock = new ProtectedMock<MyProtected>();
            var mocked = mock.Object;
            {testSource}
        }}
    }}
}}
";
        }
    }
}
