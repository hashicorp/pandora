using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "ee1dc806b00b73458a7d0de7b05da3c56c756cfb" 

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
