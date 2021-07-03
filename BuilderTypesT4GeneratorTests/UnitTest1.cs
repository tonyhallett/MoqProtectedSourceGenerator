using System;
using ANamespace;
using Xunit;

namespace BuilderTypesT4GeneratorTests
{
    public class UnitTest1
    {
        [Fact]
        public void GeneratorDebug()
        {
            // just for debugging as vs locks when - Debug T4 Template
            BuilderTypesT4Generator.BuilderTypesGenerator.GenerateTypes(2);
        }

        [Fact]
        public void EndToEnd()
        {
            TestBuilderTypes.Execute();
        }
    }
}
