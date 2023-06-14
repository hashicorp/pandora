using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GatewayLoadBalancerTunnelInterfaceTypeConstant
{
    [Description("External")]
    External,

    [Description("Internal")]
    Internal,

    [Description("None")]
    None,
}
