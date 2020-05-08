using System;
using System.Diagnostics;
using Destructurama.Attributed;
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
            Log.Logger.Warning("Goodbye, Serilog. {id} {name}", id, name);
            Log.Logger.Error("Goodbye1, Serilog. {name}, {id}", id, name);
            Log.Logger.Error("Goodbye1, Serilog. {@userfullObject}", userfullObject);
            Console.WriteLine("Hello World!");
            Log.Logger.Error(new Exception("test"),"testing exception");
        }

       
    }
   public class VerUseFullClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = "import name";
        public string Password { get; set; } = "secure password";

        [LogMasked(ShowFirst = 2, ShowLast = 2)]
        public string Token { get; set; } = "Secure Token";
    }
}
