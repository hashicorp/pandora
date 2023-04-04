using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-01-10-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Clusters.Definition(),
        new DataStores.Definition(),
        new GuestAgents.Definition(),
        new Hosts.Definition(),
        new HybridIdentityMetadata.Definition(),
        new InventoryItems.Definition(),
        new MachineExtensions.Definition(),
        new ResourcePools.Definition(),
        new VCenters.Definition(),
        new VirtualMachineTemplates.Definition(),
        new VirtualMachines.Definition(),
        new VirtualNetworks.Definition(),
    };
}
