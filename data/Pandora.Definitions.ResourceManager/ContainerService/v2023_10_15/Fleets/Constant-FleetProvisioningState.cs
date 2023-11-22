using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.Fleets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FleetProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
