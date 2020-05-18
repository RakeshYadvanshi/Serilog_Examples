using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Destructurama;
using Masking.Serilog;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace Serilog_Examples
{
    public static class Serilog_config
    {
        public static void init()
        {
            
            Log.Logger = new LoggerConfiguration()
                //.Destructure.ByMaskingProperties(opts =>
                //{
                //    opts.PropertyNames.Add(nameof(VerUseFullClass.Name));
                //    opts.Mask = "******";
                //})
                .Destructure.UsingAttributes()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithMachineName()
                //.Enrich.FromLogContext()
                .WriteTo.ColoredConsole(LogEventLevel.Debug)
                .WriteTo.MongoDB("mongodb://localhost:27017/Serilog_Examples")
                .WriteTo.ApplicationInsights("9f366977-5797-4fba-9022-2275a3b95c66", TelemetryConverter.Traces,LogEventLevel.Verbose)
                .WriteTo.RollingFile("log-{Date}.txt",outputTemplate: "{Timestamp:yyyy-MM-dd} [{Level}] {Properties}{Message}{NewLine}{Exception}", shared: true)
                .WriteTo.RollingFile("log-1-{Date}.txt", outputTemplate: "[{Level}] {Timestamp:yyyy-MM-dd} {Message}{NewLine}{Exception}{NewLine}{Properties}",shared:true)
                .WriteTo.RollingFile(new JsonFormatter(),"log-json-{Date}.txt", shared: true)
                .CreateLogger();
        }
    }
}
