using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.ManagedCluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterStateConstant
{
    [Description("BaselineUpgrade")]
    BaselineUpgrade,

    [Description("Deploying")]
    Deploying,

    [Description("Ready")]
    Ready,

    [Description("UpgradeFailed")]
    UpgradeFailed,

    [Description("Upgrading")]
    Upgrading,

    [Description("WaitingForNodes")]
    WaitingForNodes,
}
