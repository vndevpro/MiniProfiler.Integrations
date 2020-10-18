namespace MiniProfiler.Integrations
{
    public static class CustomDbProfilerHelper
    {
        public static string GetCommands(this CustomDbProfiler dbProfiler)
        {
            return dbProfiler.ProfilerContext.GetCommands();
        }
    }
}