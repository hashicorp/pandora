using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LabServices;

public partial class Service : ServiceDefinition
{
    public string Name => "LabServices";
    public string? ResourceProvider => "Microsoft.LabServices";
}
