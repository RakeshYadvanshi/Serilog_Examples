using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace Serilog_Examples
{
    public static class Serilog_config
    {
        public static void init()
        {
            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
