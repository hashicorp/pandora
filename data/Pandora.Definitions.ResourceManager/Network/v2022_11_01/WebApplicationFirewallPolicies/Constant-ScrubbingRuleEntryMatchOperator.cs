using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScrubbingRuleEntryMatchOperatorConstant
{
    [Description("Equals")]
    Equals,

    [Description("EqualsAny")]
    EqualsAny,
}
