using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubsClustersAvailableClusterRegions;

internal class Definition : ResourceDefinition
{
    public string Name => "EventHubsClustersAvailableClusterRegions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClustersListAvailableClusterRegionOperation(),
    };
}
