using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewaySslProtocolConstant
{
    [Description("TLSv1_1")]
    TLSvOneOne,

    [Description("TLSv1_2")]
    TLSvOneTwo,

    [Description("TLSv1_0")]
    TLSvOneZero,
}
