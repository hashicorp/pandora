using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_09_02_preview.FleetMembers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FleetMemberProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Joining")]
    Joining,

    [Description("Leaving")]
    Leaving,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
