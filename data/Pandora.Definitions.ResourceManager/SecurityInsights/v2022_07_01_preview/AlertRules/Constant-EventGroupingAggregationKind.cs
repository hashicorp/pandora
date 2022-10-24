using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.AlertRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventGroupingAggregationKindConstant
{
    [Description("AlertPerResult")]
    AlertPerResult,

    [Description("SingleAlert")]
    SingleAlert,
}
