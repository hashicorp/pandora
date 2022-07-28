using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.AzureFirewalls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureFirewallSkuNameConstant
{
    [Description("AZFW_Hub")]
    AZFWHub,

    [Description("AZFW_VNet")]
    AZFWVNet,
}
