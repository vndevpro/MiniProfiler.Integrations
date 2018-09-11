# MiniProfiler.Integrations
Provide custom IDbProfiler implemenation and some utility methods around MiniProfiler components

[MiniProfiler.Integrations on NuGet](https://www.nuget.org/packages/MiniProfiler.Integrations/)

# Usage

### Install package via PM
```
Install-Package MiniProfiler.Integrations
```

### Initialize connection with the custom profiler

```
var profiler = CustomDbProfiler.Current;
using (var dbConnection = ProfiledDbConnectionFactory.New(new SqlServerDbConnectionFactory(connectionString), profiler))
{
	// DO YOUR WORKS
}
```

### Get all commands executed (Success / Fail)

```
var commands = profiler.GetCommands();
```

### Support

If you like this project then please consider a donation as a thank you.

<a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=94LQC3FKSZPHL" title="Buy me a coffee via PayPal"><img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/btn/btn_donate_SM.gif"></a>
