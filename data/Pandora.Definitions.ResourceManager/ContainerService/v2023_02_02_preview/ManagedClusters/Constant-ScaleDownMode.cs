using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScaleDownModeConstant
{
    [Description("Deallocate")]
    Deallocate,

    [Description("Delete")]
    Delete,
}
