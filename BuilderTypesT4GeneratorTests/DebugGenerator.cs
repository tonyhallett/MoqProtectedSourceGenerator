using Xunit;

namespace BuilderTypesT4GeneratorTests
{
    public class DebugGenerator
    {
        //[Fact]
        public void Debug()
        {
            // just for debugging as vs locks when - Debug T4 Template
            BuilderTypesT4Generator.BuilderTypesGenerator.GenerateTypes(2);
        }
    }
}
