using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkWatchers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtocolConstant
{
    [Description("Http")]
    Http,

    [Description("Https")]
    Https,

    [Description("Icmp")]
    Icmp,

    [Description("Tcp")]
    Tcp,
}
