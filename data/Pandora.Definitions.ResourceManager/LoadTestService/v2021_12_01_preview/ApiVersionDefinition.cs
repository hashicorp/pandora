using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.LoadTestService.v2021_12_01_preview
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-12-01-preview";
        public bool Preview => true;

        public IEnumerable<ResourceDefinition> Apis => new List<ResourceDefinition>
        {
            new LoadTests.Definition(),
        };
    }
}
