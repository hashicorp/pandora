using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChannelMappingConstant
{
    [Description("BackLeft")]
    BackLeft,

    [Description("BackRight")]
    BackRight,

    [Description("Center")]
    Center,

    [Description("FrontLeft")]
    FrontLeft,

    [Description("FrontRight")]
    FrontRight,

    [Description("LowFrequencyEffects")]
    LowFrequencyEffects,

    [Description("StereoLeft")]
    StereoLeft,

    [Description("StereoRight")]
    StereoRight,
}
