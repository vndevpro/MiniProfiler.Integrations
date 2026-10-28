# MiniProfiler.Integrations
`MiniProfiler.Integrations` provides a custom `IDbProfiler` implementation that records successfully executed and failed database commands, including command text, parameters, database and connection details, and errors. The core package includes a SQL Server connection factory. Install `MiniProfiler.Integrations.MySql` for MySQL support, or implement `IDbConnectionFactory` to integrate another provider.

On NuGet: [MiniProfiler.Integrations](https://www.nuget.org/packages/MiniProfiler.Integrations/) / [MiniProfiler.Integrations.MySQL](https://www.nuget.org/packages/MiniProfiler.Integrations.MySQL/)

# Usage

Setup is in 3 simple steps:

### 1. Install package via PM
```
Install-Package MiniProfiler.Integrations
```

### 2. Initialize connection with the custom profiler

```
var profiler = CustomDbProfiler.Current;
using (var dbConnection = ProfiledDbConnectionFactory.New(new SqlServerDbConnectionFactory(connectionString), profiler))
{
	// DO YOUR WORKS
}
```

### 3. Get all commands executed (Success / Fail)

```
var commands = profiler.GetCommands();
```

### Support

If you like this project then please consider a donation as a thank you.

<a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=94LQC3FKSZPHL" title="Buy me a coffee via PayPal"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/btn/btn_donate_SM.gif"></a>
