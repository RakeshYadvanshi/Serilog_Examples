using System;
using System.Diagnostics;
using Serilog;

namespace Serilog_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Serilog_config.init();

            Log.Logger.Information("Hello, Serilog!");
            Log.Logger.Warning("Goodbye, Serilog.");
            var userfullObject = new VerUseFullClass();
            var name = userfullObject.Name;
            var id = userfullObject.Id;
            Log.Logger.Warning("Goodbye, Serilog. {name}, {id}", id, name);

            Console.WriteLine("Hello World!");
        }

        class VerUseFullClass
        {
            public int Id { get; set; }
            public string Name { get; set; } = "import name";
        }
    }
}
