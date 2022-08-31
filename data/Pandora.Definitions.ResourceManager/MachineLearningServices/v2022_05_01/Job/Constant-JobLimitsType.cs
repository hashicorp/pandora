using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobLimitsTypeConstant
{
    [Description("Command")]
    Command,

    [Description("Sweep")]
    Sweep,
}
