using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;

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
