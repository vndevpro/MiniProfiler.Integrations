using StackExchange.Profiling.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace MiniProfiler.Integrations
{
    public static class SqlConnectionFactory
    {
        public static DbConnection New(string connectionString, IDbProfiler dbProfiler)
        {
            var connection = new ProfiledDbConnection(new SqlConnection(connectionString), dbProfiler);
            connection.Open();

            return connection;
        }
    }
}