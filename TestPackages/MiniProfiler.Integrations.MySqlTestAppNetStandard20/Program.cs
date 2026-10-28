using Dapper;
using MiniProfiler.Integrations.MySql;
using System;

namespace MiniProfiler.Integrations.MySqlTestAppNetStandard20
{
    class Program
    {
        static void Main(string[] args)
        {
            var mysqlServiceUri = Environment.GetEnvironmentVariable("DEV_MySQL_ServiceUri", EnvironmentVariableTarget.User);
            var connectionString = MySqlConnectionStringHelper.ParseServiceUri(mysqlServiceUri);

            var profiler = CustomDbProfiler.Current;
            using (var dbConnection = ProfiledDbConnectionFactory.New(new MySqlDbConnectionFactory(connectionString), profiler))
            {
                dbConnection.Execute("SELECT NOW() as MySqlServerTime");
                dbConnection.TryExecute("SELECT * FROM Users");
                dbConnection.TryExecute("SELECT COUNT(*) FROM Users");
            }

            var commands = profiler.GetCommands();

            Console.WriteLine("Executed Commands: {0}", commands);
            Console.ReadLine();
        }
    }
}
