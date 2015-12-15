using System.Data;
using System.Data.Common;
using System.Text;

namespace MiniProfiler.Integrations
{
    public static class DbCommandExtensions
    {
        public static string ExtractToText(this IDbCommand command)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("CommandType: {0}, CommandText: {1}", command.CommandType, command.CommandText);

            sb.AppendLine();
            sb.AppendLine("Parameters:");

            foreach (DbParameter parameter in command.Parameters)
            {
                sb.AppendFormat("Name: {0}, Value: {1}", parameter.ParameterName, parameter.Value);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}