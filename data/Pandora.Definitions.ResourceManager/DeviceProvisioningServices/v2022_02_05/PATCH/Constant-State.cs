using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.PATCH;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StateConstant
{
    [Description("Activating")]
    Activating,

    [Description("ActivationFailed")]
    ActivationFailed,

    [Description("Active")]
    Active,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("DeletionFailed")]
    DeletionFailed,

    [Description("FailingOver")]
    FailingOver,

    [Description("FailoverFailed")]
    FailoverFailed,

    [Description("Resuming")]
    Resuming,

    [Description("Suspended")]
    Suspended,

    [Description("Suspending")]
    Suspending,

    [Description("Transitioning")]
    Transitioning,
}
