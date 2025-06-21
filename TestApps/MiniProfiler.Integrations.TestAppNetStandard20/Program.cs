using Dapper;
using System;

namespace MiniProfiler.Integrations.TestAppNetStandard20
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Data Source=192.168.1.6;Persist Security Info=True;User ID=sa; Password=Pass@word1; Trust Server Certificate=True";

            var profiler = CustomDbProfiler.Current;
            using (var dbConnection = ProfiledDbConnectionFactory.New(new SqlServerDbConnectionFactory(connectionString), profiler))
            {
                dbConnection.Execute("SELECT GETDATE() as ServerTime");
            }

            var commands = profiler.GetCommands();

            Console.WriteLine("Executed Commands: {0}", commands);
            Console.ReadLine();
        }
    }
}
