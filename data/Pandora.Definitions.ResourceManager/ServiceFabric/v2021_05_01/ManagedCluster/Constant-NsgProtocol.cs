using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.ManagedCluster
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum NsgProtocolConstant
    {
        [Description("ah")]
        Ah,

        [Description("esp")]
        Esp,

        [Description("http")]
        Http,

        [Description("https")]
        Https,

        [Description("icmp")]
        Icmp,

        [Description("tcp")]
        Tcp,

        [Description("udp")]
        Udp,
    }
}
