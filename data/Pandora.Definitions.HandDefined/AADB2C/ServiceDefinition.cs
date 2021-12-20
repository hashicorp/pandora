using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.HandDefined.AADB2C
{
    public class Service : ServiceDefinition
    {
        public string Name => "AADB2C";
        public string? ResourceProvider => "Microsoft.AzureActiveDirectory";
        public bool Generate => true;
    }
}