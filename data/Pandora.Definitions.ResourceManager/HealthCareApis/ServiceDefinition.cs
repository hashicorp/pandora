using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HealthCareApis;

public partial class Service : ServiceDefinition
{
    public string Name => "HealthCareApis";
    public string? ResourceProvider => "Microsoft.HealthcareApis";
}
