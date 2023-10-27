using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Communication.v2023_04_01.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VerificationTypeConstant
{
    [Description("DKIM")]
    DKIM,

    [Description("DKIM2")]
    DKIMTwo,

    [Description("DMARC")]
    DMARC,

    [Description("Domain")]
    Domain,

    [Description("SPF")]
    SPF,
}
