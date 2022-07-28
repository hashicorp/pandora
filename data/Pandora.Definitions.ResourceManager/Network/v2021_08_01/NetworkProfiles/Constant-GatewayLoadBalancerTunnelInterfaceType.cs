using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkProfiles;

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
