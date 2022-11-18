using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobTypeConstant
{
    [Description("AutoML")]
    AutoML,

    [Description("Command")]
    Command,

    [Description("Pipeline")]
    Pipeline,

    [Description("Sweep")]
    Sweep,
}
