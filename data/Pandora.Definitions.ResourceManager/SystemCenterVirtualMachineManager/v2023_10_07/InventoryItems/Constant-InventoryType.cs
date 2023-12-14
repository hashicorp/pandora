using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.InventoryItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InventoryTypeConstant
{
    [Description("Cloud")]
    Cloud,

    [Description("VirtualMachine")]
    VirtualMachine,

    [Description("VirtualMachineTemplate")]
    VirtualMachineTemplate,

    [Description("VirtualNetwork")]
    VirtualNetwork,
}
