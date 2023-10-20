using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegressionPrimaryMetricsConstant
{
    [Description("NormalizedMeanAbsoluteError")]
    NormalizedMeanAbsoluteError,

    [Description("NormalizedRootMeanSquaredError")]
    NormalizedRootMeanSquaredError,

    [Description("R2Score")]
    RTwoScore,

    [Description("SpearmanCorrelation")]
    SpearmanCorrelation,
}
