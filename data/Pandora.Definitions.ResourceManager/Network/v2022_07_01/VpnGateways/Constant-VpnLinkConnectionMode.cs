using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.VpnGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VpnLinkConnectionModeConstant
{
    [Description("Default")]
    Default,

    [Description("InitiatorOnly")]
    InitiatorOnly,

    [Description("ResponderOnly")]
    ResponderOnly,
}
