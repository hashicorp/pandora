using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.AzureFirewalls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureFirewallRCActionTypeConstant
{
    [Description("Allow")]
    Allow,

    [Description("Deny")]
    Deny,
}
