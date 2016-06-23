using StackExchange.Profiling.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MiniProfiler.Integrations
{
    public class CustomDbProfiler : IDbProfiler
    {
        private readonly DbCommandContext _profilerContext;

        public DbCommandContext ProfilerContext
        {
            get { return _profilerContext; }
        }

        public CustomDbProfiler()
        {
            _profilerContext = new DbCommandContext();
        }

        private static readonly Lazy<CustomDbProfiler> LazyInitializer = new Lazy<CustomDbProfiler>(() => new CustomDbProfiler());

        public static CustomDbProfiler Current
        {
            get { return LazyInitializer.Value; }
        }

        public void ExecuteFinish(IDbCommand profiledDbCommand, SqlExecuteType executeType, DbDataReader reader)
        {
            ProfilerContext.ExecutedCommands.Add(profiledDbCommand.ExtractInfo());
        }

        public void ExecuteStart(IDbCommand profiledDbCommand, SqlExecuteType executeType)
        {
        }

        public bool IsActive
        {
            get { return true; }
        }

        public void OnError(IDbCommand profiledDbCommand, SqlExecuteType executeType, Exception exception)
        {
            var failedLog = new KeyValuePair<DbCommandInfo, string>(profiledDbCommand.ExtractInfo(), exception.ToString());
            ProfilerContext.FailedCommands.Add(failedLog);
        }

        public void ReaderFinish(IDataReader reader)
        {
        }
    }
}