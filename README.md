# MiniProfiler.Integrations
Provide custom IDbProfiler implemenation and some utility methods around MiniProfiler components

# Usage

### Install package via PM
```
Install-Package MiniProfiler.Integrations
```

### Initialize connection with the custom profiler

```
var factory = new SqlServerDbConnectionFactory(connectionString);
using (var connection = DbConnectionFactoryHelper.New(factory, CustomDbProfiler.Current))
{
    try 
    {
        // DO YOUR WORKS
    }
}
```

### Get commands executed (Success / Fail)

```
finally
{
    string commands = CustomDbProfiler.Current.ProfilerContext.GetCommands()
}
```
