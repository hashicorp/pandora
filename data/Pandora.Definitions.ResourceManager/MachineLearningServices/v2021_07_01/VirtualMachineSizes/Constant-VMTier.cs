using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.VirtualMachineSizes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMTierConstant
{
    [Description("LowPriority")]
    LowPriority,

    [Description("Spot")]
    Spot,

    [Description("Standard")]
    Standard,
}
