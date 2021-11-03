using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Cognitive
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "Cognitive";
        public string? ResourceProvider => "Microsoft.CognitiveServices";
    }
}
