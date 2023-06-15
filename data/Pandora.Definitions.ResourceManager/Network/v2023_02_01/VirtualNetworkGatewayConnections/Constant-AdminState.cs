using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualNetworkGatewayConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdminStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
