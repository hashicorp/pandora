using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.LabelingJob;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobTypeConstant
{
    [Description("AutoML")]
    AutoML,

    [Description("Command")]
    Command,

    [Description("Labeling")]
    Labeling,

    [Description("Pipeline")]
    Pipeline,

    [Description("Spark")]
    Spark,

    [Description("Sweep")]
    Sweep,
}
