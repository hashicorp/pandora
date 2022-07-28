using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VpnGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnConnectionStatusConstant
{
    [Description("Connected")]
    Connected,

    [Description("Connecting")]
    Connecting,

    [Description("NotConnected")]
    NotConnected,

    [Description("Unknown")]
    Unknown,
}
