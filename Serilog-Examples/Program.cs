using System;
using System.Diagnostics;
using Serilog;

namespace Serilog_Examples
{
    class Program
    {
        static void Main(string[] args)
        {

            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));
            

            using (var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger())
            {
                log.Information("Hello, Serilog!");
                log.Warning("Goodbye, Serilog.");
                var userfullObject = new VerUseFullClass();
               var name= userfullObject.Name;
               var id = userfullObject.Id;
                log.Warning("Goodbye, Serilog. {name}, {id}", id,  name);
            }




            Console.WriteLine("Hello World!");
        }

        class VerUseFullClass
        {
            public int Id { get; set; }
            public string Name { get; set; } = "import name";
        }
    }
}
