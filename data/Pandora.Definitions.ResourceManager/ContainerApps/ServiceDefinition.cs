using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps;

public partial class Service : ServiceDefinition
{
    public string Name => "ContainerApps";
    public string? ResourceProvider => "Microsoft.App";
}
