using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Pandamonium
{
    public class Service : ServiceDefinition
    {
        public string Name => "Pandamonium";
        public bool Generate => true;
        public string? ResourceProvider => "Microsoft.Blah";
    }
}