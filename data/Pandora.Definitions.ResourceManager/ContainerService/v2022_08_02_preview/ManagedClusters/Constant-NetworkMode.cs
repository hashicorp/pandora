using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkModeConstant
{
    [Description("bridge")]
    Bridge,

    [Description("transparent")]
    Transparent,
}
