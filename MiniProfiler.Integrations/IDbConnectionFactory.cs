using System.Data.Common;

namespace MiniProfiler.Integrations
{
    /// <summary>
    /// Connection factory interface. An implementation will be created for each kind of database.
    /// </summary>
    public interface IDbConnectionFactory
    {
        DbConnection CreateConnection();
    }
}