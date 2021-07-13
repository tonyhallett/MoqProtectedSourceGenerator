namespace EndToEndTests
{
    public static class TestSource
    {
        public static string ProtectedInSource(string myProtectedMembers, string testSource, string additionalTypes = "", string additionalUsings = "")
        {
            return GetSource(myProtectedMembers, testSource, additionalTypes, additionalUsings, false);
        }
        public static string ProtectedInSourceAsync(string myProtectedMembers, string testSource, string additionalTypes = "", string additionalUsings = "")
        {
            return GetSource(myProtectedMembers, testSource, additionalTypes, additionalUsings, true);
        }
        public static string GetSource(string myProtectedMembers, string testSource, string additionalTypes, string additionalUsings, bool isAsync)
        {
            var testReturn = isAsync ? "async Task" : "void";
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
        public {testReturn} Generate()
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
