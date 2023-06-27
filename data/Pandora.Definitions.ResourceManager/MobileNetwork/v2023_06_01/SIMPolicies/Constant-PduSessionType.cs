using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.SIMPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PduSessionTypeConstant
{
    [Description("IPv4")]
    IPvFour,

    [Description("IPv6")]
    IPvSix,
}
