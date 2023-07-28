using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClassificationMultilabelPrimaryMetricsConstant
{
    [Description("AUCWeighted")]
    AUCWeighted,

    [Description("Accuracy")]
    Accuracy,

    [Description("AveragePrecisionScoreWeighted")]
    AveragePrecisionScoreWeighted,

    [Description("IOU")]
    IOU,

    [Description("NormMacroRecall")]
    NormMacroRecall,

    [Description("PrecisionScoreWeighted")]
    PrecisionScoreWeighted,
}
