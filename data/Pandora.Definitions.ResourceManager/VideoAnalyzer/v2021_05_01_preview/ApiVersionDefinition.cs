using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-05-01-preview";
        public bool Preview => true;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new VideoAnalyzer.Definition(),
        };
    }
}
