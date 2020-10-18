using Dapper;
using MiniProfiler.Integrations.MySql;

namespace MiniProfiler.Integrations.MySqlTestAppNet462
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"";

            var profiler = CustomDbProfiler.Current;
            using (var dbConnection = ProfiledDbConnectionFactory.New(new MySqlDbConnectionFactory(connectionString), profiler))
            {
                dbConnection.Execute("SELECT GETDATE() as ServerTime");
            }

            var commands = profiler.GetCommands();
        }
    }
}
