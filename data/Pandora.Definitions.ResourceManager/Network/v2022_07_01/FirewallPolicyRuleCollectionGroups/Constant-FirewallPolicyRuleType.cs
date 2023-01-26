using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.FirewallPolicyRuleCollectionGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirewallPolicyRuleTypeConstant
{
    [Description("ApplicationRule")]
    ApplicationRule,

    [Description("NatRule")]
    NatRule,

    [Description("NetworkRule")]
    NetworkRule,
}
