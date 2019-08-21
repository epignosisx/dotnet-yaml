using System.IO;
using System.Linq;

namespace System.CommandLine.Builder
{
    public static class ArgumentExtensions
    {
        public static Argument<string> ExistingFileOrDirectoryOnly(this Argument<string> argument)
        {
            argument.AddValidator(symbol =>
                symbol.Tokens
                    .Select(t => t.Value)
                    .Where(filePath => !Directory.Exists(filePath) && !File.Exists(filePath))
                    .Select(FileOrDirectoryDoesNotExist)
                    .FirstOrDefault());
            return argument;
        }

        private static string FileOrDirectoryDoesNotExist(string path) =>
            $"File or directory does not exist: {path}";
    }
}

