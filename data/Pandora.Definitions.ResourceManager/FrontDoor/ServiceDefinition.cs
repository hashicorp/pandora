using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "FrontDoor";
        public string? ResourceProvider => "Microsoft.Network";
    }
}
