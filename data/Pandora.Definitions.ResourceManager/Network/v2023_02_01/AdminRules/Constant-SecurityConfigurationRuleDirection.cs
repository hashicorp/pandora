using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.AdminRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityConfigurationRuleDirectionConstant
{
    [Description("Inbound")]
    Inbound,

    [Description("Outbound")]
    Outbound,
}
