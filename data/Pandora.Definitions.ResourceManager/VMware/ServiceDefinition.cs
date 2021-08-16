using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "VMware";
        public string? ResourceProvider => "Microsoft.AVS";
    }
}
