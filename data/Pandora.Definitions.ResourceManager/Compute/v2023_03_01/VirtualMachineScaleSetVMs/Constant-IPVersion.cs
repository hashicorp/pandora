using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineScaleSetVMs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPVersionConstant
{
    [Description("IPv4")]
    IPvFour,

    [Description("IPv6")]
    IPvSix,
}
