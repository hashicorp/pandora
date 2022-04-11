using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnvironmentProvisioningStateConstant
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

    [Description("UpgradeFailed")]
    UpgradeFailed,

    [Description("UpgradeRequested")]
    UpgradeRequested,

    [Description("Waiting")]
    Waiting,
}
