using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthBot.v2023_05_01.Healthbots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("C0")]
    CZero,

    [Description("F0")]
    FZero,

    [Description("PES")]
    PES,

    [Description("S1")]
    SOne,
}
