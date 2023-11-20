using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.NamespacesNetworkSecurityPerimeterConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NspAccessRuleDirectionConstant
{
    [Description("Inbound")]
    Inbound,

    [Description("Outbound")]
    Outbound,
}
