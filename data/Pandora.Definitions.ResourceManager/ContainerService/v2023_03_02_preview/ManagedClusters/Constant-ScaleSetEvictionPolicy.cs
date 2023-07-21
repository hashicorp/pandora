using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_03_02_preview.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScaleSetEvictionPolicyConstant
{
    [Description("Deallocate")]
    Deallocate,

    [Description("Delete")]
    Delete,
}
