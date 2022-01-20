using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Relay;

public partial class Service : ServiceDefinition
{
    public string Name => "Relay";
    public string? ResourceProvider => "Microsoft.Relay";
}
