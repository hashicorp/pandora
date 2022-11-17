using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.ManagedCluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterUpgradeCadenceConstant
{
    [Description("Wave1")]
    WaveOne,

    [Description("Wave2")]
    WaveTwo,

    [Description("Wave0")]
    WaveZero,
}
