using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Regions
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "ce90f9b45945c73b8f38649ee6ead390ff6efe7b" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "Regions";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ListBySkuOperation(),
        };
    }
}
