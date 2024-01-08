using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.VirtualNetworkTap;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityRuleDirectionConstant
{
    [Description("Inbound")]
    Inbound,

    [Description("Outbound")]
    Outbound,
}
