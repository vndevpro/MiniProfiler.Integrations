using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProfiler.Integrations
{
    public class DbCommandContext
    {
        private readonly IList<string> _executedCommands = new List<string>();
        private readonly IList<string> _failedCommands = new List<string>();

        public IList<string> ExecutedCommands
        {
            get { return _executedCommands; }
        }

        public IList<string> FailedCommands
        {
            get { return _failedCommands; }
        }

        public void Reset()
        {
            _executedCommands.Clear();
            _failedCommands.Clear();
        }

        /// <summary>
        /// Get all commands have been executed successfully or failed
        /// </summary>
        public string GetCommands()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("ExecutedCommands: {0}", string.Join(Environment.NewLine + "----" + Environment.NewLine, ExecutedCommands.ToArray()));
            sb.AppendLine("--------------");
            sb.AppendFormat("FailedCommands: {0}", string.Join(Environment.NewLine + "----" + Environment.NewLine, FailedCommands.ToArray()));
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
