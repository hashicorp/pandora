using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.LocalRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DecryptionRuleTypeEnumConstant
{
    [Description("None")]
    None,

    [Description("SSLInboundInspection")]
    SSLInboundInspection,

    [Description("SSLOutboundInspection")]
    SSLOutboundInspection,
}
