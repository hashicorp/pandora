using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_07_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeinterlaceModeConstant
{
    [Description("AutoPixelAdaptive")]
    AutoPixelAdaptive,

    [Description("Off")]
    Off,
}
