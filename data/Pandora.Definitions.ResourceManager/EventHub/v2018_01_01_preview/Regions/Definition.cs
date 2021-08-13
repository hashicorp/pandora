using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Regions
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1e9e2b41c471029b643e58f65caccdd0492a1576" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "Regions";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ListBySkuOperation(),
        };
    }
}
