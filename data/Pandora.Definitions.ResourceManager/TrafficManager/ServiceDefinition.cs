using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.TrafficManager;

public partial class Service : ServiceDefinition
{
    public string Name => "TrafficManager";
    public string? ResourceProvider => "Microsoft.Network";
}
