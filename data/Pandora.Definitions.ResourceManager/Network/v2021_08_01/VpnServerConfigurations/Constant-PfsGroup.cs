using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VpnServerConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PfsGroupConstant
{
    [Description("ECP384")]
    ECPThreeEightFour,

    [Description("ECP256")]
    ECPTwoFiveSix,

    [Description("None")]
    None,

    [Description("PFSMM")]
    PFSMM,

    [Description("PFS1")]
    PFSOne,

    [Description("PFS14")]
    PFSOneFour,

    [Description("PFS2")]
    PFSTwo,

    [Description("PFS24")]
    PFSTwoFour,

    [Description("PFS2048")]
    PFSTwoZeroFourEight,
}
