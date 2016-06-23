using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProfiler.Integrations
{
    public class DbCommandContext
    {
        public event ReviewCommandTextEventHandler<CommandEventArgs> CommandGetting;

        private readonly IList<DbCommandInfo> _executedCommands = new List<DbCommandInfo>();
        private readonly IList<KeyValuePair<DbCommandInfo, string>> _failedCommands = new List<KeyValuePair<DbCommandInfo, string>>();

        public IList<DbCommandInfo> ExecutedCommands
        {
            get { return _executedCommands; }
        }

        public IList<KeyValuePair<DbCommandInfo, string>> FailedCommands
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

            var commandList = ExecutedCommands
                .Select(x => x.Recreate(OnCommandGetting(x.CommandText)))
                .Select(x => x.ExtractToText());

            sb.AppendFormat("ExecutedCommands: {0}", string.Join(Environment.NewLine + "----" + Environment.NewLine, commandList));
            sb.AppendLine("--------------");

            var failedLogs = FailedCommands.Select(x => string.Format("Command: {0}, Error: {1}", x.Key, x.Value));
            sb.AppendFormat("FailedCommands: {0}", string.Join(Environment.NewLine + "----" + Environment.NewLine, failedLogs));
            sb.AppendLine();

            return sb.ToString();
        }

        private string OnCommandGetting(string commandText)
        {
            return (CommandGetting != null) ? CommandGetting(this, new CommandEventArgs(commandText)) : commandText;
        }
    }
}
