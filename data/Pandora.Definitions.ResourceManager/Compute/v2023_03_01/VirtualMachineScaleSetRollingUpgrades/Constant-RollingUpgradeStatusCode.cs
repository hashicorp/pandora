using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineScaleSetRollingUpgrades;

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
