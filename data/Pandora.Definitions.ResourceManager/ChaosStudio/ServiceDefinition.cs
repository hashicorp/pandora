using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "ChaosStudio";
        public string? ResourceProvider => "Microsoft.Chaos";
    }
}
