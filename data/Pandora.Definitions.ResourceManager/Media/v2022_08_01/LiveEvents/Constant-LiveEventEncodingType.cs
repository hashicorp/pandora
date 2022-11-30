using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.LiveEvents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LiveEventEncodingTypeConstant
{
    [Description("None")]
    None,

    [Description("PassthroughBasic")]
    PassthroughBasic,

    [Description("PassthroughStandard")]
    PassthroughStandard,

    [Description("Premium1080p")]
    PremiumOneZeroEightZerop,

    [Description("Standard")]
    Standard,
}
