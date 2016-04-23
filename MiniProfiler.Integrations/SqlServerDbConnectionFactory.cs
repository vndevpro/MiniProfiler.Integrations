using System.Data.Common;
using System.Data.SqlClient;

namespace MiniProfiler.Integrations
{
    /// <summary>
    /// SQL Server connection factory
    /// </summary>
    public class SqlServerDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlServerDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}