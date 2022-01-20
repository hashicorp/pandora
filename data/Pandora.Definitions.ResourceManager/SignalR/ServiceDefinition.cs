using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SignalR;

public partial class Service : ServiceDefinition
{
    public string Name => "SignalR";
    public string? ResourceProvider => "Microsoft.SignalRService";
}
