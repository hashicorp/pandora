using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DNSResolver.v2022_07_01.ForwardingRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ForwardingRuleStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
