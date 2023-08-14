using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualMachineRestrictMovementStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
