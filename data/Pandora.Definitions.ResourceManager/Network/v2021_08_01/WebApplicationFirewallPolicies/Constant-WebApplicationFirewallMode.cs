using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebApplicationFirewallModeConstant
{
    [Description("Detection")]
    Detection,

    [Description("Prevention")]
    Prevention,
}
