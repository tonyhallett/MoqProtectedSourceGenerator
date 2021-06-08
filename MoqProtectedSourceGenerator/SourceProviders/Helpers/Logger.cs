using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class Logger : ILogger, ISourceProvider
    {
        private readonly int minLogCount;
        private readonly List<(string message, string caller)> logs = new();
        private readonly string hintName;
        public Logger(string hintName = "log", bool onlyCreateSourceIfLogged = true)
        {
            minLogCount = onlyCreateSourceIfLogged ? 0 : -1;
            this.hintName = hintName;
        }


        private string GetLogString()
        {
            var sb = new StringBuilder();
            foreach (var log in logs)
            {
                var caller = string.IsNullOrEmpty(log.caller) ? "" : $"[{log.caller}]";
                sb.Append(caller);
                sb.Append(log.message);
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public void AddSource(GeneratorExecutionContext context)
        {
            if (logs.Count > minLogCount)
            {
                context.AddSource(hintName, $@"
/*
{GetLogString()}
*/
");
            }
        }

        public void Log(string message, string caller = "")
        {
            logs.Add((message, caller));
        }
    }
}
