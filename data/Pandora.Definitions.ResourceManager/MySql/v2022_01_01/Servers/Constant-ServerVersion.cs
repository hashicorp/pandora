using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2022_01_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerVersionConstant
{
    [Description("8.0.21")]
    EightPointZeroPointTwoOne,

    [Description("5.7")]
    FivePointSeven,
}
