using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Media;

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
