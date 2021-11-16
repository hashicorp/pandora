using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Communication
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "Communication";
        public string? ResourceProvider => "Microsoft.Communication";
    }
}
