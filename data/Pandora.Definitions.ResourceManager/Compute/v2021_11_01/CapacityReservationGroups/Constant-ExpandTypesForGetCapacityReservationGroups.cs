using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.CapacityReservationGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpandTypesForGetCapacityReservationGroupsConstant
{
    [Description("virtualMachineScaleSetVMs/$ref")]
    VirtualMachineScaleSetVMsRef,

    [Description("virtualMachines/$ref")]
    VirtualMachinesRef,
}
