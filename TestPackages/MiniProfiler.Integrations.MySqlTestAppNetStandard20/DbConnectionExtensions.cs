using Dapper;
using System;
using System.Data.Common;

namespace MiniProfiler.Integrations.MySqlTestAppNetStandard20
{
    static class DbConnectionExtensions
    {
        public static void TryExecute(this DbConnection connection, string sql)
        {
            try
            {
                connection.Execute(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing SQL: {ex.Message}");
            }
        }
    }
}
