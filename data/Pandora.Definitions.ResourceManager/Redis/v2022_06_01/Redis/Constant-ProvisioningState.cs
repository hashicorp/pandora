using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Redis.v2022_06_01.Redis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Disabled")]
    Disabled,

    [Description("Failed")]
    Failed,

    [Description("Linking")]
    Linking,

    [Description("Provisioning")]
    Provisioning,

    [Description("RecoveringScaleFailure")]
    RecoveringScaleFailure,

    [Description("Scaling")]
    Scaling,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unlinking")]
    Unlinking,

    [Description("Unprovisioning")]
    Unprovisioning,

    [Description("Updating")]
    Updating,
}
