using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.PrivateLinkService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TransportProtocolConstant
{
    [Description("All")]
    All,

    [Description("Tcp")]
    Tcp,

    [Description("Udp")]
    Udp,
}
