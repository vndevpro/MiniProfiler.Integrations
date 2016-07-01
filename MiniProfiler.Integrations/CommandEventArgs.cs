using System;

namespace MiniProfiler.Integrations
{
    /// <summary>
    /// Argument event for getting command
    /// </summary>
    public class CommandEventArgs : EventArgs
    {
        private readonly string _commandText;

        /// <summary>
        /// Create new argument with a command text
        /// </summary>
        public CommandEventArgs(string commandText)
        {
            _commandText = commandText;
        }

        /// <summary>
        /// Get the command text
        /// </summary>
        public string CommandText
        {
            get { return _commandText; }
        }
    }
}