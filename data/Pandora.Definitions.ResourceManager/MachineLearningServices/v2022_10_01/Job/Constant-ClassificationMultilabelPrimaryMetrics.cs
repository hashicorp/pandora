using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;

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
