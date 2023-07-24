using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineScaleSetVMs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskControllerTypesConstant
{
    [Description("NVMe")]
    NVMe,

    [Description("SCSI")]
    SCSI,
}
