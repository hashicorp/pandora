using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.AzureFirewalls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureFirewallNatRCActionTypeConstant
{
    [Description("Dnat")]
    Dnat,

    [Description("Snat")]
    Snat,
}
