using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayTierConstant
{
    [Description("Standard")]
    Standard,

    [Description("Standard_v2")]
    StandardVTwo,

    [Description("WAF")]
    WAF,

    [Description("WAF_v2")]
    WAFVTwo,
}
