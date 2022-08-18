using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.Dns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecordTypeConstant
{
    [Description("A")]
    A,

    [Description("AAAA")]
    AAAA,

    [Description("CAA")]
    CAA,

    [Description("CNAME")]
    CNAME,

    [Description("MX")]
    MX,

    [Description("NS")]
    NS,

    [Description("PTR")]
    PTR,

    [Description("SOA")]
    SOA,

    [Description("SRV")]
    SRV,

    [Description("TXT")]
    TXT,
}
