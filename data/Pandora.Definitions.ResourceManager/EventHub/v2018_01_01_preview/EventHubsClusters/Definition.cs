using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "0cfcacb4d5b58433bfa7cf811f20b1d233cd4dac" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "EventHubsClusters";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ClustersCreateOrUpdateOperation(),
            new ClustersDeleteOperation(),
            new ClustersGetOperation(),
            new ClustersListByResourceGroupOperation(),
            new ClustersUpdateOperation(),
        };
    }
}
