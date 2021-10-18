using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataBricks
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "DataBricks";
        public string? ResourceProvider => "Microsoft.Databricks";
    }
}
