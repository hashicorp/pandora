using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.ApplicationGatewayPrivateEndpointConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicIPAddressDnsSettingsDomainNameLabelScopeConstant
{
    [Description("NoReuse")]
    NoReuse,

    [Description("ResourceGroupReuse")]
    ResourceGroupReuse,

    [Description("SubscriptionReuse")]
    SubscriptionReuse,

    [Description("TenantReuse")]
    TenantReuse,
}
