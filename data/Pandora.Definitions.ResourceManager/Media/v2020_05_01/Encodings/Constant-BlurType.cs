using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BlurTypeConstant
{
    [Description("Black")]
    Black,

    [Description("Box")]
    Box,

    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Med")]
    Med,
}
