using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubsClusters;

internal class Definition : ResourceDefinition
{
    public string Name => "EventHubsClusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClustersCreateOrUpdateOperation(),
        new ClustersDeleteOperation(),
        new ClustersGetOperation(),
        new ClustersListByResourceGroupOperation(),
        new ClustersListBySubscriptionOperation(),
        new ClustersUpdateOperation(),
    };
}
