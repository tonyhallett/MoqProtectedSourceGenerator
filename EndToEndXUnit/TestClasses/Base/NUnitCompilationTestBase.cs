using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace EndToEndTests
{
    public abstract class NUnitCompilationTestBase
    {
        private const string EmitDll = "emit.dll";
        private string EmitDllPath
        {
            get
            {
                if (!Directory.Exists(EmitFolder))
                {
                    Directory.CreateDirectory(EmitFolder);
                }
                return Path.Combine(EmitFolder, EmitDll);
            }
        }

        // Cannot delete UnauthorizedAccessException - testhost.exe
        protected abstract string EmitFolder { get; set; } 

        public void Test()
        {
            SetUpDlls();
            ExecuteTestsAndAssert();
        }

        protected abstract void CopyDlls(string emitFolder);

        protected abstract Compilation CreateCompilation();

        private void SetUpDlls()
        {
            Emit();
            CopyDlls(EmitFolder);
        }

        private void Emit()
        {
            Compilation compilation = CreateCompilation();

            var diagnostics = compilation.GetDiagnostics();
            if (diagnostics.Length > 0)
            {
                GroupedDiagnosticLogger.LogDiagnostics("compilation", diagnostics);
            }

            
            AssertionHelpers.NoDiagnosticErrors(diagnostics);

            var emitResult = compilation.Emit(EmitDllPath);
            if (!emitResult.Success)
            {
                GroupedDiagnosticLogger.LogDiagnostics("emit failure", emitResult.Diagnostics);
            }

            Assert.True(emitResult.Success, "Unsuccessful emit");

        }

        private void LogTestReports(IEnumerable<string> reports)
        {
            foreach (var report in reports)
            {
                Debug.WriteLine(report);
            }
        }

        private void ExecuteTestsAndAssert()
        {
            var nunitTestRunner = new NUnitTestRunner();
            var testRun = nunitTestRunner.Run(EmitDllPath);

            var testSuites = testRun.TestSuites;
            var testSuite = testSuites[0];
            Assert.True(testSuites.Count == 1, "Expected single test suite");
            Assert.True(testSuite.Total == 1, "Expected single test");
            if (testSuite.Passed != 1)
            {
                LogTestReports(nunitTestRunner.Reports);
            }
            Assert.True(testSuite.Passed == 1, "Test failed");
        }

    }
}
