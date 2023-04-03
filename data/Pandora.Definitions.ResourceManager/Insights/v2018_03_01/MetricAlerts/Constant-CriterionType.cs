using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CriterionTypeConstant
{
    [Description("DynamicThresholdCriterion")]
    DynamicThresholdCriterion,

    [Description("StaticThresholdCriterion")]
    StaticThresholdCriterion,
}
