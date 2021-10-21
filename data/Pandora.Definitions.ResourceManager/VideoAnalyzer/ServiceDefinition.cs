using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "VideoAnalyzer";
        public string? ResourceProvider => "Microsoft.Media";
    }
}
