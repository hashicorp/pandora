using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.PowerBIDedicated
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1e9e2b41c471029b643e58f65caccdd0492a1576" 

        public string ApiVersion => "2021-01-01";
        public string Name => "PowerBIDedicated";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CapacitiesListSkusOperation(),
        };
    }
}
