using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DhGroupConstant
{
    [Description("DHGroup1")]
    DHGroupOne,

    [Description("DHGroup14")]
    DHGroupOneFour,

    [Description("DHGroup2")]
    DHGroupTwo,

    [Description("DHGroup24")]
    DHGroupTwoFour,

    [Description("DHGroup2048")]
    DHGroupTwoZeroFourEight,

    [Description("ECP384")]
    ECPThreeEightFour,

    [Description("ECP256")]
    ECPTwoFiveSix,

    [Description("None")]
    None,
}
