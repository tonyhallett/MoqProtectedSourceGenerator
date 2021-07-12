using System.Collections.Generic;
using NUnit.Engine;

namespace EndToEndTests
{
    public class ReportCollector : ITestEventListener
    {
        private readonly List<string> reports = new List<string>();
        public IEnumerable<string> Reports => reports;
        /// <summary>
        /// Implementation of ITestEventListener.OnTestEvent method.
        /// </summary>
        /// <param name="report">The test event report.</param>
        public void OnTestEvent(string report)
        {
            reports.Add(report);
        }
    }
}
