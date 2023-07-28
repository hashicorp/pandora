using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ForecastingPrimaryMetricsConstant
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
