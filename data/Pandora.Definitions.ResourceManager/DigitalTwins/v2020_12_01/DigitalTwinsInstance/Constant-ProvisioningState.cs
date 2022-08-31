using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2020_12_01.DigitalTwinsInstance;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Moving")]
    Moving,

    [Description("Provisioning")]
    Provisioning,

    [Description("Restoring")]
    Restoring,

    [Description("Succeeded")]
    Succeeded,

    [Description("Suspending")]
    Suspending,

    [Description("Updating")]
    Updating,

    [Description("Warning")]
    Warning,
}
