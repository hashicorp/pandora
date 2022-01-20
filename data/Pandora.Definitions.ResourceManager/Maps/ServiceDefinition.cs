using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maps;

public partial class Service : ServiceDefinition
{
    public string Name => "Maps";
    public string? ResourceProvider => "Microsoft.Maps";
}
