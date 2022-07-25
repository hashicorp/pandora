using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.MachineLearningComputes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AllocationStateConstant
{
    [Description("Resizing")]
    Resizing,

    [Description("Steady")]
    Steady,
}
