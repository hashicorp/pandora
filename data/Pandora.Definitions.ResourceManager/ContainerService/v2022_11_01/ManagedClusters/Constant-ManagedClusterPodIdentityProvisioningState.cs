using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_11_01.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedClusterPodIdentityProvisioningStateConstant
{
    [Description("Assigned")]
    Assigned,

    [Description("Canceled")]
    Canceled,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
