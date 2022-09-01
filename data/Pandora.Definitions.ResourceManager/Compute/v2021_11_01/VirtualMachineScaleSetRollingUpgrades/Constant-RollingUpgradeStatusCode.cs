using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSetRollingUpgrades;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RollingUpgradeStatusCodeConstant
{
    [Description("Cancelled")]
    Cancelled,

    [Description("Completed")]
    Completed,

    [Description("Faulted")]
    Faulted,

    [Description("RollingForward")]
    RollingForward,
}
