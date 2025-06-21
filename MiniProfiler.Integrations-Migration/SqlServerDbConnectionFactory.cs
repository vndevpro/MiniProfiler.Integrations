using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace MiniProfiler.Integrations
{
    /// <summary>
    /// SQL Server connection factory
    /// </summary>
    public class SqlServerDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        /// <param name="connectionString"></param>
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