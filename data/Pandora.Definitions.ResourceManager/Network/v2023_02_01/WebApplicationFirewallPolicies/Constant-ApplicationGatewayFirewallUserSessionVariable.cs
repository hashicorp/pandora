using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayFirewallUserSessionVariableConstant
{
    [Description("ClientAddr")]
    ClientAddr,

    [Description("GeoLocation")]
    GeoLocation,

    [Description("None")]
    None,
}
