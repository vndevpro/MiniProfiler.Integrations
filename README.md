# MiniProfiler.Integrations
Provide custom IDbProfiler implemenation and some utility methods around MiniProfiler components

# Usage

1. Initialize connection with the custom profiler

using (var connection = SqlConnectionFactory.New(connectionString, CustomDbProfiler.Current))
{
    // DO YOUR WORKS
}

2. Get commands executed (Success / Fail)

string commands = CustomDbProfiler.Current.ProfilerContext.GetCommands()
