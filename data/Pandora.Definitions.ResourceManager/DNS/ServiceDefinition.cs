using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DNS;

public partial class Service : ServiceDefinition
{
    public string Name => "DNS";
    public string? ResourceProvider => "Microsoft.Network";
}
