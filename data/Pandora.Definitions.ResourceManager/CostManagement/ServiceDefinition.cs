using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CostManagement
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "CostManagement";
        public string? ResourceProvider => "Microsoft.CostManagement";
    }
}
