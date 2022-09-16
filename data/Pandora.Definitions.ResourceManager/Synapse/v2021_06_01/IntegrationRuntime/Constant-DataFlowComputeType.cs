using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataFlowComputeTypeConstant
{
    [Description("ComputeOptimized")]
    ComputeOptimized,

    [Description("General")]
    General,

    [Description("MemoryOptimized")]
    MemoryOptimized,
}
