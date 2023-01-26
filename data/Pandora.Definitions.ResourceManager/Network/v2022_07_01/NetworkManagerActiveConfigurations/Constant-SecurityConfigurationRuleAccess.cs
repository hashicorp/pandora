using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkManagerActiveConfigurations;

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
