using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.ManagedClusterSnapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkPolicyConstant
{
    [Description("azure")]
    Azure,

    [Description("calico")]
    Calico,

    [Description("cilium")]
    Cilium,
}
