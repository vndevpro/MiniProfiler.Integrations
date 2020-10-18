using Dapper;

namespace MiniProfiler.Integrations.TestAppPackageNet462
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Server=.\SqlExpress;Integrated Security=True;";

            var profiler = CustomDbProfiler.Current;
            using (var dbConnection = ProfiledDbConnectionFactory.New(new SqlServerDbConnectionFactory(connectionString), profiler))
            {
                dbConnection.Execute("SELECT GETDATE() as ServerTime");
            }

            var commands = profiler.GetCommands();
        }
    }
}
