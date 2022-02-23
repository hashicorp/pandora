using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage;

public partial class Service : ServiceDefinition
{
    public string Name => "Storage";
    public string? ResourceProvider => "Microsoft.Storage";
}
