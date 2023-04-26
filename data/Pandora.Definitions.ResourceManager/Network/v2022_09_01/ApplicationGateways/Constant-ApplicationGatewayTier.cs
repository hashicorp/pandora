using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.ApplicationGateways;

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
