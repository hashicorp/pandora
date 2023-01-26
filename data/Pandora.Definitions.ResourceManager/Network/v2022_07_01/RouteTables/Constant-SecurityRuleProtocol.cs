using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.RouteTables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityRuleProtocolConstant
{
    [Description("Ah")]
    Ah,

    [Description("*")]
    Any,

    [Description("Esp")]
    Esp,

    [Description("Icmp")]
    Icmp,

    [Description("Tcp")]
    Tcp,

    [Description("Udp")]
    Udp,
}
