using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PacketCaptures;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PcProtocolConstant
{
    [Description("Any")]
    Any,

    [Description("TCP")]
    TCP,

    [Description("UDP")]
    UDP,
}
