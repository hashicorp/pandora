using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ManagedCluster
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum DirectionConstant
    {
        [Description("inbound")]
        Inbound,

        [Description("outbound")]
        Outbound,
    }
}
