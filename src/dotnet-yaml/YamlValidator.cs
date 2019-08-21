using System.IO;
using SharpYaml;
using SharpYaml.Serialization;

namespace Epignosisx.DotNet.Yaml
{
    public static class YamlValidator
    {
        public static bool Validate(Logger logger, string filename)
        {
            try
            {
                var content = File.ReadAllText(filename);
                var yaml = new YamlStream();
                yaml.Load(new StringReader(content));
                logger.Verbose($"{filename}: valid");
                return true;
            }
            catch(SyntaxErrorException ex)
            {
                logger.Error($"{filename} invalid: {ex.Start.ToString()}");
                return false;
            }
        }
    }
}