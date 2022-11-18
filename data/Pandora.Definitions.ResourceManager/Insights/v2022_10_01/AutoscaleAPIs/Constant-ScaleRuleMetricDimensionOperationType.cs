using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_10_01.AutoscaleAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScaleRuleMetricDimensionOperationTypeConstant
{
    [Description("Equals")]
    Equals,

    [Description("NotEquals")]
    NotEquals,
}
