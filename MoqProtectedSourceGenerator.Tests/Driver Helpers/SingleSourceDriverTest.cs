using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Xunit;

namespace MoqProtectedSourceGenerator.Tests
{
    public static class SingleSourceDriverTest
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");

        public static GeneratedSourceResult GetGeneratedSourceResult(Compilation inputCompilation, ISourceGenerator generator, string hintName)
        {
            var generatedSources = SingleGeneratorDriverTest.RunTest(inputCompilation, generator);
            return generatedSources.First(gs => gs.HintName == hintName);
        }

        public static string GetGeneratedSource(Compilation inputCompilation, ISourceGenerator generator, string hintName)
        {
            var generatedSource = GetGeneratedSourceResult(inputCompilation, generator, hintName).SourceText.ToString();
            return generatedSource;
        }

        public static void AssertEqualGeneratedSource(Compilation inputCompilation, ISourceGenerator generator, string hintName, string expectedSource, AssertEqualGeneratedSourceOptions options = default)
        {
            var generatedSource = GetGeneratedSource(inputCompilation, generator, hintName);
            Exception throwException = null;
            try
            {
                // although https://github.com/xunit/xunit/issues/2133 https://github.com/xunit/xunit/issues/1931
                // Assert.Equal(expectedSource, generatedSource, options.IgnoreLineEndingDifferences, options.IgnoreWhiteSpaceDifferences);

                // for now
                if (options.IgnoreWhiteSpaceDifferences)
                {
                    Assert.Equal(RemoveWhitespace(expectedSource), RemoveWhitespace(generatedSource));
                }
                else
                {
                    Assert.Equal(expectedSource, generatedSource);
                }

            }
            catch (Exception exc)
            {
                throwException = exc;
            }

            if (throwException != null)
            {
                if (!string.IsNullOrWhiteSpace(options.WriteToFileIfFails))
                {
                    File.WriteAllText(options.WriteToFileIfFails, generatedSource);
                }

                throw throwException;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(options.WriteToFileIfFails))
                {
                    if (File.Exists(options.WriteToFileIfFails))
                    {
                        File.Delete(options.WriteToFileIfFails);
                    }
                }
            }
        }

        private static string RemoveWhitespace(string input)
        {
            return sWhitespace.Replace(input, "");
        }
    }

}
