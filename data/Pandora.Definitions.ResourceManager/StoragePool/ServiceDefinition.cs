using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StoragePool;

public partial class Service : ServiceDefinition
{
    public string Name => "StoragePool";
    public string? ResourceProvider => "Microsoft.StoragePool";
}
