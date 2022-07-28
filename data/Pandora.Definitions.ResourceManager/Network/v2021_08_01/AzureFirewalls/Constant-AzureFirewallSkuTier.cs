using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.AzureFirewalls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureFirewallSkuTierConstant
{
    [Description("Basic")]
    Basic,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
