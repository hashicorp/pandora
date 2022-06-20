using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VmPriorityConstant
{
    [Description("Dedicated")]
    Dedicated,

    [Description("LowPriority")]
    LowPriority,
}
