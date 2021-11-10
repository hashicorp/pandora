using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabric
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "ServiceFabric";
        public string? ResourceProvider => "Microsoft.ServiceFabric";
    }
}
