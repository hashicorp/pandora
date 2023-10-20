using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRulestacks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityServicesTypeEnumConstant
{
    [Description("antiSpyware")]
    AntiSpyware,

    [Description("antiVirus")]
    AntiVirus,

    [Description("dnsSubscription")]
    DnsSubscription,

    [Description("fileBlocking")]
    FileBlocking,

    [Description("ipsVulnerability")]
    IPsVulnerability,

    [Description("urlFiltering")]
    UrlFiltering,
}
