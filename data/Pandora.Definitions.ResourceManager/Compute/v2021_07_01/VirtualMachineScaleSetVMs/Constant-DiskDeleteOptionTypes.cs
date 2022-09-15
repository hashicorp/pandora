using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSetVMs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskDeleteOptionTypesConstant
{
    [Description("Delete")]
    Delete,

    [Description("Detach")]
    Detach,
}
