using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;

internal class Definition : ResourceDefinition
{
    public string Name => "HybridKubernetes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConnectedClusterCreateOperation(),
        new ConnectedClusterDeleteOperation(),
        new ConnectedClusterGetOperation(),
        new ConnectedClusterListByResourceGroupOperation(),
        new ConnectedClusterListBySubscriptionOperation(),
        new ConnectedClusterListClusterUserCredentialOperation(),
        new ConnectedClusterUpdateOperation(),
    };
}
