using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub
{
    public class Service : ServiceDefinition
    {
        public string Name => "EventHub";
        public bool Generate => true;
        public string? ResourceProvider => "Microsoft.EventHub";
    }
}