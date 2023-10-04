using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-10-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Clusters.Definition(),
        new DataStores.Definition(),
        new Hosts.Definition(),
        new InventoryItems.Definition(),
        new ResourcePools.Definition(),
        new VCenters.Definition(),
        new VMInstanceGuestAgents.Definition(),
        new VMInstanceHybridIdentityMetadata.Definition(),
        new VirtualMachineInstances.Definition(),
        new VirtualMachineTemplates.Definition(),
        new VirtualNetworks.Definition(),
    };
}
