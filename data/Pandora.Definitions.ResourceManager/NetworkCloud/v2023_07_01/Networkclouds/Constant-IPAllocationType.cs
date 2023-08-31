using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPAllocationTypeConstant
{
    [Description("DualStack")]
    DualStack,

    [Description("IPV4")]
    IPVFour,

    [Description("IPV6")]
    IPVSix,
}
