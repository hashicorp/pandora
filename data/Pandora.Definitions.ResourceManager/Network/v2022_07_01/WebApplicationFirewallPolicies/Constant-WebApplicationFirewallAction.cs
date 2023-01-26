using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebApplicationFirewallActionConstant
{
    [Description("Allow")]
    Allow,

    [Description("Block")]
    Block,

    [Description("Log")]
    Log,
}
