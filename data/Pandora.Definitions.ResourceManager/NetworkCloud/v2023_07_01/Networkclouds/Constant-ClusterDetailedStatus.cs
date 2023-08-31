using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterDetailedStatusConstant
{
    [Description("Degraded")]
    Degraded,

    [Description("Deleting")]
    Deleting,

    [Description("Deploying")]
    Deploying,

    [Description("Disconnected")]
    Disconnected,

    [Description("Failed")]
    Failed,

    [Description("PendingDeployment")]
    PendingDeployment,

    [Description("Running")]
    Running,

    [Description("Updating")]
    Updating,
}
