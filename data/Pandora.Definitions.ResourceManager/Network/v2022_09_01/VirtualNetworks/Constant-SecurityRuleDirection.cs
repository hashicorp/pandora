using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.VirtualNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityRuleDirectionConstant
{
    [Description("Inbound")]
    Inbound,

    [Description("Outbound")]
    Outbound,
}
