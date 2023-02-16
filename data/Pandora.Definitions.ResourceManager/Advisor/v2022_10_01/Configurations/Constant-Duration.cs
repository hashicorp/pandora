using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DurationConstant
{
    [Description("90")]
    NineZero,

    [Description("14")]
    OneFour,

    [Description("7")]
    Seven,

    [Description("60")]
    SixZero,

    [Description("30")]
    ThreeZero,

    [Description("21")]
    TwoOne,
}
