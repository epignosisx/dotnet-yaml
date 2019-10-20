using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;

namespace Epignosisx.DotNet.Yaml
{
    public class CommandLineApplication
    {
        public RootCommand RootCommand { get; }

        public CommandLineApplication()
        {
            Option inputOpt = new Option(new string[]{"-i", "--input"}, "File or directory to process");
            inputOpt.Argument = new Argument<string>().ExistingFileOrDirectoryOnly();
            inputOpt.Argument.Arity = ArgumentArity.ExactlyOne;
            inputOpt.Argument.SetDefaultValue(".");

            Option filterOpt = new Option(new string[]{"-f", "--filter"}, "Glob to filter directory input. Defaults to .yml and .yaml files in top level dir.");
            filterOpt.Argument = new Argument<string[]>();
            filterOpt.Argument.Arity = ArgumentArity.ZeroOrMore;
            filterOpt.Argument.SetDefaultValue(new string[] { "*.yaml", "*.yml" });

            Option verboseOpt = new Option(new string[]{"-v", "--verbose"}, "Verbose output");
            verboseOpt.Argument = new Argument<bool>();

            RootCommand = new RootCommand();
            RootCommand.Description = "Validates format of YAML files";
            RootCommand.AddOption(inputOpt);
            RootCommand.AddOption(filterOpt);
            RootCommand.AddOption(verboseOpt);

            RootCommand.Handler = CommandHandler.Create<IConsole, string, string[], bool>((console, input, filter, verbose) => 
                ValidatorCommand.Execute(new Logger(console, verbose), input, filter)
            );
        }
    }
}