using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.VirtualWANs;

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
