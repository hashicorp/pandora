using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.NetworkManagerEffectiveSecurityAdminRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityConfigurationRuleAccessConstant
{
    [Description("Allow")]
    Allow,

    [Description("AlwaysAllow")]
    AlwaysAllow,

    [Description("Deny")]
    Deny,
}
