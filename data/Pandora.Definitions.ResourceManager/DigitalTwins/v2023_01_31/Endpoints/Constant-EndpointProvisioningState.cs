using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31.Endpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("Disabled")]
    Disabled,

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
