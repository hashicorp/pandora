using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration;

public partial class Service : ServiceDefinition
{
    public string Name => "KubernetesConfiguration";
    public string? ResourceProvider => "Microsoft.KubernetesConfiguration";
}
