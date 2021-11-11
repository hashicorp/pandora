using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedCluster
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ProtocolConstant
    {
        [Description("tcp")]
        Tcp,

        [Description("udp")]
        Udp,
    }
}
