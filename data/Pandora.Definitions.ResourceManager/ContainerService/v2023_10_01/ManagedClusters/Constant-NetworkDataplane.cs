using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkDataplaneConstant
{
    [Description("azure")]
    Azure,

    [Description("cilium")]
    Cilium,
}
