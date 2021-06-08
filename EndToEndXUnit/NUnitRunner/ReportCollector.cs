using System.Collections.Generic;
using NUnit.Engine;

namespace EndToEndTests
{
    public class ReportCollector : ITestEventListener
    {
        public readonly List<string> Reports = new List<string>();
        /// <summary>
        /// Implementation of ITestEventListener.OnTestEvent method.
        /// </summary>
        /// <param name="report">The test event report.</param>
        public void OnTestEvent(string report)
        {
            Reports.Add(report);
        }
    }
}
