using System.Collections.Generic;
using System.Data;

namespace MiniProfiler.Integrations
{
    public class DbCommandInfo
    {
        /// <summary>
        /// Create new object with empty information for all properties
        /// </summary>
        public DbCommandInfo()
        {
            Parameters = new Dictionary<string, object>();
        }

        /// <summary>
        /// Type of command, how the command text is used
        /// </summary>
        public CommandType CommandType { get; set; }

        /// <summary>
        /// Command text which is executing
        /// </summary>
        public string CommandText { get; set; }

        /// <summary>
        /// The database inwhich the command will be executed on
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Connection string to open the connection
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// All parameters of the command
        /// </summary>
        public IDictionary<string, object> Parameters { get; private set; }
    }
}