using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.MachineLearningComputes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NodeStateConstant
{
    [Description("idle")]
    Idle,

    [Description("leaving")]
    Leaving,

    [Description("preempted")]
    Preempted,

    [Description("preparing")]
    Preparing,

    [Description("running")]
    Running,

    [Description("unusable")]
    Unusable,
}
