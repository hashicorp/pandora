using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AnalysisServices
{
    public partial class Service : ServiceDefinition
    {
        public string Name => "AnalysisServices";
        public string? ResourceProvider => "Microsoft.AnalysisServices";
    }
}
