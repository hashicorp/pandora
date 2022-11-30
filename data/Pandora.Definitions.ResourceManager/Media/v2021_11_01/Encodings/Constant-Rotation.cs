using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RotationConstant
{
    [Description("Auto")]
    Auto,

    [Description("None")]
    None,

    [Description("Rotate90")]
    RotateNineZero,

    [Description("Rotate180")]
    RotateOneEightZero,

    [Description("Rotate270")]
    RotateTwoSevenZero,

    [Description("Rotate0")]
    RotateZero,
}
