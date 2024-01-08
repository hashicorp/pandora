using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.BastionHosts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BastionConnectProtocolConstant
{
    [Description("RDP")]
    RDP,

    [Description("SSH")]
    SSH,
}
