using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ConnectedEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectedEnvironmentProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("InfrastructureSetupComplete")]
    InfrastructureSetupComplete,

    [Description("InfrastructureSetupInProgress")]
    InfrastructureSetupInProgress,

    [Description("InitializationInProgress")]
    InitializationInProgress,

    [Description("ScheduledForDelete")]
    ScheduledForDelete,

    [Description("Succeeded")]
    Succeeded,

    [Description("Waiting")]
    Waiting,
}
