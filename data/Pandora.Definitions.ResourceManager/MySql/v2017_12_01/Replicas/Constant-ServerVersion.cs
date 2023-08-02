using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2017_12_01.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerVersionConstant
{
    [Description("8.0")]
    EightPointZero,

    [Description("5.7")]
    FivePointSeven,

    [Description("5.6")]
    FivePointSix,
}
