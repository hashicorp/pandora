using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_07_01.ManagedHsmKeys;

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
