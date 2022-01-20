using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise;

public partial class Service : ServiceDefinition
{
    public string Name => "RedisEnterprise";
    public string? ResourceProvider => "Microsoft.Cache";
}
