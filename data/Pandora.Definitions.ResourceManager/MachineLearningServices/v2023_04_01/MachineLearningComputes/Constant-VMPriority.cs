using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.MachineLearningComputes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMPriorityConstant
{
    [Description("Dedicated")]
    Dedicated,

    [Description("LowPriority")]
    LowPriority,
}
