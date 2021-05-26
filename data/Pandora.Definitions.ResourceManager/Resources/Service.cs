using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources
{
    public class Service : ServiceDefinition
    {
        public string Name => "resources";
        public bool Generate => true;
        public string? ResourceProvider => "Microsoft.Resources";
    }
}