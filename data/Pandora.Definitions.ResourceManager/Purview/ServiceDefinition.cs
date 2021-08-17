using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "Purview";
        public string? ResourceProvider => "Microsoft.Purview";
    }
}
