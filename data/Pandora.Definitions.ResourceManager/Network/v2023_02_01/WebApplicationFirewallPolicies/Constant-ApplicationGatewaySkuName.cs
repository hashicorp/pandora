using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewaySkuNameConstant
{
    [Description("Standard_Large")]
    StandardLarge,

    [Description("Standard_Medium")]
    StandardMedium,

    [Description("Standard_Small")]
    StandardSmall,

    [Description("Standard_v2")]
    StandardVTwo,

    [Description("WAF_Large")]
    WAFLarge,

    [Description("WAF_Medium")]
    WAFMedium,

    [Description("WAF_v2")]
    WAFVTwo,
}
