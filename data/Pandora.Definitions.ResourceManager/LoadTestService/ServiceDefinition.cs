using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService;

public partial class Service : ServiceDefinition
{
    public string Name => "LoadTestService";
    public string? ResourceProvider => "Microsoft.LoadTestService";
}
