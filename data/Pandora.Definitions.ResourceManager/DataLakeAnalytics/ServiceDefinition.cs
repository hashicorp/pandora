using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics;

public partial class Service : ServiceDefinition
{
    public string Name => "DataLakeAnalytics";
    public string? ResourceProvider => "Microsoft.DataLakeAnalytics";
}
