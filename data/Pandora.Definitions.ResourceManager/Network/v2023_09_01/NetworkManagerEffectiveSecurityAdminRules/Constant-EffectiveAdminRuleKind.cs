using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkManagerEffectiveSecurityAdminRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EffectiveAdminRuleKindConstant
{
    [Description("Custom")]
    Custom,

    [Description("Default")]
    Default,
}
