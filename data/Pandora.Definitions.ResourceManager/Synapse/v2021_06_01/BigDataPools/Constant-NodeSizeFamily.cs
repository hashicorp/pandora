using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.BigDataPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NodeSizeFamilyConstant
{
    [Description("HardwareAcceleratedFPGA")]
    HardwareAcceleratedFPGA,

    [Description("HardwareAcceleratedGPU")]
    HardwareAcceleratedGPU,

    [Description("MemoryOptimized")]
    MemoryOptimized,

    [Description("None")]
    None,
}
