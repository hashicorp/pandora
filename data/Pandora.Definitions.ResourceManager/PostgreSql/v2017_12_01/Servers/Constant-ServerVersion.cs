using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerVersionConstant
{
    [Description("9.5")]
    NinePointFive,

    [Description("9.6")]
    NinePointSix,

    [Description("11")]
    OneOne,

    [Description("10")]
    OneZero,

    [Description("10.2")]
    OneZeroPointTwo,

    [Description("10.0")]
    OneZeroPointZero,
}
