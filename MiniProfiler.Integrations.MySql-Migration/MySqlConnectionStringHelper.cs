using MySql.Data.MySqlClient;
using System;

namespace MiniProfiler.Integrations.MySql
{
    public static class MySqlConnectionStringHelper
    {
        /// <summary>
        /// Parses a service URI and returns a MySQL connection string.
        /// </summary>
        public static string ParseServiceUri(string serviceUri)
        {
            var uri = new Uri(serviceUri);
            var builder = new MySqlConnectionStringBuilder
            {
                Server = uri.Host,
                Port = (uint)(uri.Port == -1 ? 3306 : uri.Port),
                Database = uri.AbsolutePath.TrimStart('/')
            };

            if (!string.IsNullOrEmpty(uri.UserInfo))
            {
                var userInfo = uri.UserInfo.Split(':');
                builder.UserID = Uri.UnescapeDataString(userInfo[0]);
                if (userInfo.Length > 1)
                    builder.Password = Uri.UnescapeDataString(userInfo[1]);
            }

            return builder.ConnectionString;
        }
    }
}
