using StackExchange.Profiling.Data;
using System.Data.Common;

namespace MiniProfiler.Integrations
{
    public static class DbConnectionFactoryHelper
    {
        /// <summary>
        /// Creates a ProfiledDbConnection instance and opens it
        /// </summary>
        public static DbConnection New(IDbConnectionFactory connectionFactory, IDbProfiler dbProfiler)
        {
            var connection = new ProfiledDbConnection(connectionFactory.CreateConnection(), dbProfiler);
            connection.Open();

            return connection;
        }
    }
}