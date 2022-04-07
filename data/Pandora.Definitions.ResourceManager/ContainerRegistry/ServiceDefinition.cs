using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry;

public partial class Service : ServiceDefinition
{
    public string Name => "ContainerRegistry";
    public string? ResourceProvider => "Microsoft.ContainerRegistry";
}
