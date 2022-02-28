using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Elastic;

public partial class Service : ServiceDefinition
{
    public string Name => "Elastic";
    public string? ResourceProvider => "Microsoft.Elastic";
}
