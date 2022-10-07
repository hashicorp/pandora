using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.AgentPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentPoolTypeConstant
{
    [Description("AvailabilitySet")]
    AvailabilitySet,

    [Description("VirtualMachineScaleSets")]
    VirtualMachineScaleSets,
}
