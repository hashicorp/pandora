using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.ExpressRouteLinks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpressRouteLinkMacSecCipherConstant
{
    [Description("GcmAes128")]
    GcmAesOneTwoEight,

    [Description("GcmAes256")]
    GcmAesTwoFiveSix,

    [Description("GcmAesXpn128")]
    GcmAesXpnOneTwoEight,

    [Description("GcmAesXpn256")]
    GcmAesXpnTwoFiveSix,
}
