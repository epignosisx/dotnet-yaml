using System;
using System.CommandLine.Invocation;

namespace Epignosisx.DotNet.Yaml
{
    class Program
    {
        private const int ERROR = 2;

        public static int Main(string[] args)
        {
            try 
            {
                var app = new CommandLineApplication();
                return app.RootCommand.Invoke(args);
            } 
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Unexpected error: " + ex.ToString());
                Console.ResetColor();
                return ERROR;
            }
        }
    }
}
