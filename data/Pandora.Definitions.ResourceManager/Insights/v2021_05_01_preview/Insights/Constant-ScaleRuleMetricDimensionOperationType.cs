using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.Insights;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScaleRuleMetricDimensionOperationTypeConstant
{
    [Description("Equals")]
    Equals,

    [Description("NotEquals")]
    NotEquals,
}
