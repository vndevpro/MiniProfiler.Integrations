using Dapper;
using MiniProfiler.Integrations.MySql;
using System;

namespace MiniProfiler.Integrations.MySqlTestAppNetStandard20
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Server= 192.168.1.6;Database=mysql;Uid=root;Pwd=Pass@word1;";

            var profiler = CustomDbProfiler.Current;
            using (var dbConnection = ProfiledDbConnectionFactory.New(new MySqlDbConnectionFactory(connectionString), profiler))
            {
                dbConnection.Execute("SELECT NOW() as MySqlServerTime");
            }

            var commands = profiler.GetCommands();

            Console.WriteLine("Executed Commands: {0}", commands);
            Console.ReadLine();
        }
    }
}
