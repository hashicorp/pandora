using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TargetAggregationFunctionConstant
{
    [Description("Max")]
    Max,

    [Description("Mean")]
    Mean,

    [Description("Min")]
    Min,

    [Description("None")]
    None,

    [Description("Sum")]
    Sum,
}
