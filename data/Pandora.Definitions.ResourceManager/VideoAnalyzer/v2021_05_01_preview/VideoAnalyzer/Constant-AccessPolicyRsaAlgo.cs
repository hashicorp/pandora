using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum AccessPolicyRsaAlgoConstant
    {
        [Description("RS512")]
        RSFiveOneTwo,

        [Description("RS384")]
        RSThreeEightFour,

        [Description("RS256")]
        RSTwoFiveSix,
    }
}
