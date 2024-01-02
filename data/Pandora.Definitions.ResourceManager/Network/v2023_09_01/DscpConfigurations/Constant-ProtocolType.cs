using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.DscpConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtocolTypeConstant
{
    [Description("Ah")]
    Ah,

    [Description("All")]
    All,

    [Description("DoNotUse")]
    DoNotUse,

    [Description("Esp")]
    Esp,

    [Description("Gre")]
    Gre,

    [Description("Icmp")]
    Icmp,

    [Description("Tcp")]
    Tcp,

    [Description("Udp")]
    Udp,

    [Description("Vxlan")]
    Vxlan,
}
