using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterStateConstant
{
    [Description("AutoScale")]
    AutoScale,

    [Description("BaselineUpgrade")]
    BaselineUpgrade,

    [Description("Deploying")]
    Deploying,

    [Description("EnforcingClusterVersion")]
    EnforcingClusterVersion,

    [Description("Ready")]
    Ready,

    [Description("UpdatingInfrastructure")]
    UpdatingInfrastructure,

    [Description("UpdatingUserCertificate")]
    UpdatingUserCertificate,

    [Description("UpdatingUserConfiguration")]
    UpdatingUserConfiguration,

    [Description("UpgradeServiceUnreachable")]
    UpgradeServiceUnreachable,

    [Description("WaitingForNodes")]
    WaitingForNodes,
}
