using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes;

public partial class Service : ServiceDefinition
{
    public string Name => "HybridKubernetes";
    public string? ResourceProvider => "Microsoft.Kubernetes";
}
