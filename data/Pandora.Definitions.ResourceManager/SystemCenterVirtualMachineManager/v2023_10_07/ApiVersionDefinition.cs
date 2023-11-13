using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-10-07";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AvailabilitySets.Definition(),
        new Clouds.Definition(),
        new InventoryItems.Definition(),
        new VMInstanceGuestAgents.Definition(),
        new VMInstanceHybridIdentityMetadata.Definition(),
        new VMmServers.Definition(),
        new VirtualMachineInstances.Definition(),
        new VirtualMachineTemplates.Definition(),
        new VirtualNetworks.Definition(),
    };
}
