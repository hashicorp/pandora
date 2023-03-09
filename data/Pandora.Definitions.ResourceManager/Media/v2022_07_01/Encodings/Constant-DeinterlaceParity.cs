using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_07_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeinterlaceParityConstant
{
    [Description("Auto")]
    Auto,

    [Description("BottomFieldFirst")]
    BottomFieldFirst,

    [Description("TopFieldFirst")]
    TopFieldFirst,
}
