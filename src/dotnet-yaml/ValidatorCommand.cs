using System.IO;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace Epignosisx.DotNet.Yaml
{
    public static class ValidatorCommand
    {
        public static int Execute(Logger logger, string input, string[] filters)
        {
            bool success = true;
            if (Directory.Exists(input))
            {
                var matcher = new Matcher();
                if (filters == null || filters.Length == 0)
                {
                    matcher.AddInclude("*.yaml");
                    matcher.AddInclude("*.yml");
                }
                else
                {
                    foreach(var filter in filters)
                        matcher.AddInclude(filter);
                }

                var dirInfo = new DirectoryInfo(input);
                var results = matcher.Execute(new DirectoryInfoWrapper(dirInfo));

                foreach(var match in results.Files)
                {
                    success &= YamlValidator.Validate(logger, match.Path);
                }
            }
            else
            {
                success &= YamlValidator.Validate(logger, input);
            }

            return success ? 0 : 1;
        }
    }
}