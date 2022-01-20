using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity;

public partial class Service : ServiceDefinition
{
    public string Name => "ManagedIdentity";
    public string? ResourceProvider => "Microsoft.ManagedIdentity";
}
