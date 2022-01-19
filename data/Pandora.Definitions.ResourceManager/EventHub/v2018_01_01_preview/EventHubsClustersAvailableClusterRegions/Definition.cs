using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClustersAvailableClusterRegions
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "EventHubsClustersAvailableClusterRegions";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new ClustersListAvailableClusterRegionOperation(),
        };
    }
}
