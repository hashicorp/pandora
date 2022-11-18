using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.ManagedCluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NsgProtocolConstant
{
    [Description("ah")]
    Ah,

    [Description("esp")]
    Esp,

    [Description("http")]
    HTTP,

    [Description("https")]
    HTTPS,

    [Description("icmp")]
    Icmp,

    [Description("tcp")]
    Tcp,

    [Description("udp")]
    Udp,
}
