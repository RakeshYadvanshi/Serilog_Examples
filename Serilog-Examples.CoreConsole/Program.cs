using System;
using System.Diagnostics;
using System.Threading;
using Destructurama.Attributed;
using Serilog;

namespace Serilog_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Serilog_config.init();
            Thread.Sleep(2000);
            loging().Information("1-1");
            Thread.Sleep(2000);
            loging().Warning("Goodbye, Serilog.");
            var userfullObject = new VerUseFullClass();
            Thread.Sleep(2000);
            var name = userfullObject.Name;
            var id = userfullObject.Id;
            Thread.Sleep(2000);
            Thread.Sleep(2000);
            loging().Warning("Goodbye, Serilog. {id} {name}", id, name);
            Thread.Sleep(2000);
            loging().Error("Goodbye1, Serilog. {name}, {id}", id, name);
            Thread.Sleep(2000);
            loging().Error("Goodbye1, Serilog. {@userfullObject}", userfullObject);
            loging().Error("Goodbye1, Serilog. @{userfullObject}", userfullObject);
            Thread.Sleep(2000);
            Console.WriteLine("Hello World!");
            Thread.Sleep(2000);
            loging().Information("2-2");

            loging().Error(new Exception("test"),"testing exception");
            Thread.Sleep(2000);
           
        }

        public static ILogger loging()
        {
           
            return Log.Logger;
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
