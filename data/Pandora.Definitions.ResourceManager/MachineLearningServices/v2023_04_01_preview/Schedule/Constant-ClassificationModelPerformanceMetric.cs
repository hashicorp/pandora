using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClassificationModelPerformanceMetricConstant
{
    [Description("Accuracy")]
    Accuracy,

    [Description("F1Score")]
    FOneScore,

    [Description("Precision")]
    Precision,

    [Description("Recall")]
    Recall,
}
