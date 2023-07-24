using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineScaleSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualMachinePriorityTypesConstant
{
    [Description("Low")]
    Low,

    [Description("Regular")]
    Regular,

    [Description("Spot")]
    Spot,
}
