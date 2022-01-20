using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataLakeStore;

public partial class Service : ServiceDefinition
{
    public string Name => "DataLakeStore";
    public string? ResourceProvider => "Microsoft.DataLakeStore";
}
