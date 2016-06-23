using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace MiniProfiler.Integrations
{
    public static class DbCommandExtensions
    {
        public static DbCommandInfo ExtractInfo(this IDbCommand command)
        {
            var info = new DbCommandInfo()
            {
                CommandType = command.CommandType,
                CommandText = command.CommandText
            };

            foreach (DbParameter parameter in command.Parameters)
            {
                info.Parameters.Add(new KeyValuePair<string, object>(parameter.ParameterName, parameter.Value));
            }

            return info;
        }

        public static DbCommandInfo Recreate(this DbCommandInfo commandInfo, string commandText)
        {
            var info = new DbCommandInfo()
            {
                CommandType = commandInfo.CommandType,
                CommandText = commandText
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