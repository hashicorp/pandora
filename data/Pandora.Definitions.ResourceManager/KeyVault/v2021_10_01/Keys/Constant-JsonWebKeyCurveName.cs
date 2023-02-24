using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Keys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JsonWebKeyCurveNameConstant
{
    [Description("P-521")]
    PNegativeFiveTwoOne,

    [Description("P-384")]
    PNegativeThreeEightFour,

    [Description("P-256")]
    PNegativeTwoFiveSix,

    [Description("P-256K")]
    PNegativeTwoFiveSixK,
}
