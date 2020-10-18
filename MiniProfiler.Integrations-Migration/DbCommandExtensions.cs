using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace MiniProfiler.Integrations
{
    public static class DbCommandExtensions
    {
        /// <summary>
        /// Extract information from command to a light object
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static DbCommandInfo ExtractInfo(this IDbCommand command)
        {
            var info = new DbCommandInfo()
            {
                CommandType = command.CommandType,
                CommandText = command.CommandText,
                Database = command.Connection.Database,
                ConnectionString = command.Connection.ConnectionString
            };

            foreach (DbParameter parameter in command.Parameters)
            {
                info.Parameters.Add(new KeyValuePair<string, object>(parameter.ParameterName, parameter.Value));
            }

            return info;
        }

        /// <summary>
        /// Create new instance with new command text
        /// </summary>
        public static DbCommandInfo Recreate(this DbCommandInfo commandInfo, string commandText)
        {
            var info = new DbCommandInfo()
            {
                CommandText = commandText,
                CommandType = commandInfo.CommandType,
                Database = commandInfo.Database,
                ConnectionString = commandInfo.ConnectionString
            };

            foreach (var parameter in commandInfo.Parameters)
            {
                info.Parameters.Add(new KeyValuePair<string, object>(parameter.Key, parameter.Value));
            }

            return info;
        }

        public static string ExtractToText(this DbCommandInfo commandInfo)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("CommandType: {0}, CommandText: {1}", commandInfo.CommandType, commandInfo.CommandText);
            sb.AppendLine();
            sb.AppendFormat("Database: {0}, ConnectionString: {1}", commandInfo.Database, commandInfo.ConnectionString);
            sb.AppendLine();
            sb.AppendLine("Parameters:");

            foreach (var parameter in commandInfo.Parameters)
            {
                sb.AppendFormat("Name: {0}, Value: {1}", parameter.Key, parameter.Value);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
