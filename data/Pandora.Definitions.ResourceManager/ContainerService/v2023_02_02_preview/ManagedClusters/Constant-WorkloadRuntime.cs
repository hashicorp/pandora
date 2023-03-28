using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkloadRuntimeConstant
{
    [Description("KataMshvVmIsolation")]
    KataMshvVMIsolation,

    [Description("OCIContainer")]
    OCIContainer,

    [Description("WasmWasi")]
    WasmWasi,
}
