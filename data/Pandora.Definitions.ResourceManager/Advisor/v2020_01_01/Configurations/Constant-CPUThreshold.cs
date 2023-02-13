using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2020_01_01.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CPUThresholdConstant
{
    [Description("5")]
    Five,

    [Description("15")]
    OneFive,

    [Description("10")]
    OneZero,

    [Description("20")]
    TwoZero,
}
