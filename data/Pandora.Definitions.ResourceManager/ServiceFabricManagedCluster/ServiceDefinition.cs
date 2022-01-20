using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster;

public partial class Service : ServiceDefinition
{
    public string Name => "ServiceFabricManagedCluster";
    public string? ResourceProvider => "Microsoft.ServiceFabric";
}
