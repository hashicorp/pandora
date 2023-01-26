using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.SecurityPartnerProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityPartnerProviderConnectionStatusConstant
{
    [Description("Connected")]
    Connected,

    [Description("NotConnected")]
    NotConnected,

    [Description("PartiallyConnected")]
    PartiallyConnected,

    [Description("Unknown")]
    Unknown,
}
