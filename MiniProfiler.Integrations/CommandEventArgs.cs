using System;

namespace MiniProfiler.Integrations
{
    public class CommandEventArgs : EventArgs
    {
        private readonly string _commandText;

        public CommandEventArgs(string commandText)
        {
            _commandText = commandText;
        }

        public string CommandText
        {
            get { return _commandText; }
        }
    }
}