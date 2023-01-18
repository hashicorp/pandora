using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SigningAlgorithmConstant
{
    [Description("Default")]
    Default,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("SHA1")]
    SHAOne,

    [Description("SHA2512")]
    SHATwoFiveOneTwo,

    [Description("SHA2384")]
    SHATwoThreeEightFour,

    [Description("SHA2256")]
    SHATwoTwoFiveSix,
}
