using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.FirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum FirewallPolicyIDPSSignatureDirectionConstant
{
    [Description("4")]
    Four,

    [Description("1")]
    One,

    [Description("3")]
    Three,

    [Description("2")]
    Two,

    [Description("0")]
    Zero,
}
