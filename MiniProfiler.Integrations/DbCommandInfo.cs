using System.Collections.Generic;
using System.Data;

namespace MiniProfiler.Integrations
{
    public class DbCommandInfo
    {
        public DbCommandInfo()
        {
            Parameters = new Dictionary<string, object>();
        }

        public CommandType CommandType { get; set; }

        public string CommandText { get; set; }

        public IDictionary<string, object> Parameters { get; private set; }
    }
}