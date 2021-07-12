using System.Collections.Generic;
using System.IO;
using NUnit.Engine;

namespace EndToEndTests
{
    public class NUnitTestRunner
    {
        private string testAssemblyDirectory;
        private string testAssembly;
        private ReportCollector reportCollector;
        public IEnumerable<string> Reports { get; private set; }

        public TestRun Run(string testAssembly)
        {
            SetPaths(testAssembly);

            using ITestEngine nunitEngine = TestEngineActivator.CreateInstance();
            nunitEngine.WorkDirectory = testAssemblyDirectory;
            
            // Run all the tests in the assembly
            var emptyTestFilter = this.GetEmptyTestFilter(nunitEngine);

            using var runner = nunitEngine.GetRunner(CreateTestPackage());
            var result =  RunAndConvert(runner, emptyTestFilter);

            return result;
        }

        private void SetPaths(string testAssembly)
        {
            testAssemblyDirectory = Path.GetDirectoryName(testAssembly);
            this.testAssembly = testAssembly;
        }

        private TestFilter GetEmptyTestFilter(ITestEngine nunitEngine)
        {
            var filterService = nunitEngine.Services.GetService<ITestFilterService>();
            var builder = filterService.GetTestFilterBuilder();
            var filter = builder.GetFilter();
            return filter;
        }

        private TestPackage CreateTestPackage()
        {
            var package = new TestPackage(testAssembly);
            package.AddSetting(NUnit.EnginePackageSettings.WorkDirectory, testAssemblyDirectory);
            package.AddSetting(NUnit.EnginePackageSettings.ShadowCopyFiles, true);
            package.AddSetting(NUnit.EnginePackageSettings.DisposeRunners, true);
            package.AddSetting(NUnit.EnginePackageSettings.InternalTraceLevel, "Verbose");
            return package;
        }

        private TestRun RunAndConvert(ITestRunner runner, TestFilter filter)
        {
            reportCollector = new ReportCollector();
            var testResult = runner.Run(reportCollector, filter);
            Reports = reportCollector.Reports;
            return TestRun.Create(testResult);
        }


    }
}
