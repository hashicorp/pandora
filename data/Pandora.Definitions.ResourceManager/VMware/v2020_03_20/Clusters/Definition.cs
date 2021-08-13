using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Clusters
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "1e9e2b41c471029b643e58f65caccdd0492a1576" 

        public string ApiVersion => "2020-03-20";
        public string Name => "Clusters";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
            new UpdateOperation(),
        };
    }
}
