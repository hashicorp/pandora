using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.Environments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("L1")]
    LOne,

    [Description("P1")]
    POne,

    [Description("S1")]
    SOne,

    [Description("S2")]
    STwo,
}
