using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.VirtualNetworkTaps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoadBalancerBackendAddressAdminStateConstant
{
    [Description("Down")]
    Down,

    [Description("Drain")]
    Drain,

    [Description("None")]
    None,

    [Description("Up")]
    Up,
}
