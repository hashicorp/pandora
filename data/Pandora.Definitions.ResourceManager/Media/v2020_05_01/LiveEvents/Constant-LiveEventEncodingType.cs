using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.LiveEvents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LiveEventEncodingTypeConstant
{
    [Description("None")]
    None,

    [Description("Premium1080p")]
    PremiumOneZeroEightZerop,

    [Description("Standard")]
    Standard,
}
