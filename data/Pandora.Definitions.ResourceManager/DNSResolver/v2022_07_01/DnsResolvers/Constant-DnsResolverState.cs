using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DNSResolver.v2022_07_01.DnsResolvers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DnsResolverStateConstant
{
    [Description("Connected")]
    Connected,

    [Description("Disconnected")]
    Disconnected,
}
