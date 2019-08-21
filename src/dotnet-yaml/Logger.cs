using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Epignosisx.DotNet.Yaml
{
    public class Logger
    {
        private readonly IConsole _console;
        private readonly bool _verbose;

        public Logger(IConsole console, bool verbose)
        {
            _console = console;
            _verbose = verbose;
        }

        public void Verbose(string message)
        {
            if (_verbose) _console.Out.WriteLine(message);
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _console.Error.WriteLine(message);
            Console.ResetColor();
        }
    }
}