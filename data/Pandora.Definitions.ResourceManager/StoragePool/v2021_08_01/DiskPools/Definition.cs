using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools;

internal class Definition : ResourceDefinition
{
    public string Name => "DiskPools";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeallocateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListOutboundNetworkDependenciesEndpointsOperation(),
        new StartOperation(),
        new UpdateOperation(),
        new UpgradeOperation(),
    };
}
