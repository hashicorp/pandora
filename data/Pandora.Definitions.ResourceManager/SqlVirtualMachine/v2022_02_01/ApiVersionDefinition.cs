using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-02-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AvailabilityGroupListeners.Definition(),
        new SqlVirtualMachineGroups.Definition(),
        new SqlVirtualMachines.Definition(),
    };
}
