using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkWatchers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtocolConstant
{
    [Description("Http")]
    HTTP,

    [Description("Https")]
    HTTPS,

    [Description("Icmp")]
    Icmp,

    [Description("Tcp")]
    Tcp,
}
