using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2018_09_01.RecordSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecordTypeConstant
{
    [Description("A")]
    A,

    [Description("AAAA")]
    AAAA,

    [Description("CNAME")]
    CNAME,

    [Description("MX")]
    MX,

    [Description("PTR")]
    PTR,

    [Description("SOA")]
    SOA,

    [Description("SRV")]
    SRV,

    [Description("TXT")]
    TXT,
}
