using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.Videos;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPolicyEccAlgoConstant
{
    [Description("ES512")]
    ESFiveOneTwo,

    [Description("ES384")]
    ESThreeEightFour,

    [Description("ES256")]
    ESTwoFiveSix,
}
