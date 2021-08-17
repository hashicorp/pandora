using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersAvailableClusterRegions
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e68d33c8165c51219c4643eead40efd6a9ab7bd2" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "EventHubsClustersAvailableClusterRegions";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ClustersListAvailableClusterRegionOperation(),
        };
    }
}
