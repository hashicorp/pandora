using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayRedirectTypeConstant
{
    [Description("Found")]
    Found,

    [Description("Permanent")]
    Permanent,

    [Description("SeeOther")]
    SeeOther,

    [Description("Temporary")]
    Temporary,
}
