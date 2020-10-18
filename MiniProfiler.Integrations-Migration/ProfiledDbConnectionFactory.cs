using StackExchange.Profiling.Data;
using System.Data.Common;

namespace MiniProfiler.Integrations
{
    public static class ProfiledDbConnectionFactory
    {
        /// <summary>
        /// Creates a ProfiledDbConnection instance and opens it
        /// </summary>
        public static DbConnection New(IDbConnectionFactory connectionFactory, IDbProfiler dbProfiler)
        {
            return new ProfiledDbConnection(connectionFactory.CreateConnection(), dbProfiler);
        }
    }
}