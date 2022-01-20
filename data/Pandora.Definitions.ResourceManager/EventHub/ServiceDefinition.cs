using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub;

public partial class Service : ServiceDefinition
{
    public string Name => "EventHub";
    public string? ResourceProvider => "Microsoft.EventHub";
}
