using Dapper;

namespace MiniProfiler.Integrations.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Server=.\SqlExpress;Integrated Security=True;";

            var profiler = CustomDbProfiler.Current;
            var dbConnection = ProfiledDbConnectionFactory.New(new SqlServerDbConnectionFactory(connectionString), profiler);

            dbConnection.Execute("SELECT GETDATE() as ServerTime");

            var commands = profiler.GetCommands();
        }
    }
}
