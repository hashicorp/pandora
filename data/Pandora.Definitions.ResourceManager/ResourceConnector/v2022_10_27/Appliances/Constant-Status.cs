using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ResourceConnector.v2022_10_27.Appliances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Connected")]
    Connected,

    [Description("Connecting")]
    Connecting,

    [Description("ImageDeprovisioning")]
    ImageDeprovisioning,

    [Description("ImageDownloaded")]
    ImageDownloaded,

    [Description("ImageDownloading")]
    ImageDownloading,

    [Description("ImagePending")]
    ImagePending,

    [Description("ImageProvisioned")]
    ImageProvisioned,

    [Description("ImageProvisioning")]
    ImageProvisioning,

    [Description("ImageUnknown")]
    ImageUnknown,

    [Description("None")]
    None,

    [Description("Offline")]
    Offline,

    [Description("PostUpgrade")]
    PostUpgrade,

    [Description("PreUpgrade")]
    PreUpgrade,

    [Description("PreparingForUpgrade")]
    PreparingForUpgrade,

    [Description("Running")]
    Running,

    [Description("UpdatingCAPI")]
    UpdatingCAPI,

    [Description("UpdatingCloudOperator")]
    UpdatingCloudOperator,

    [Description("UpdatingCluster")]
    UpdatingCluster,

    [Description("UpgradeClusterExtensionFailedToDelete")]
    UpgradeClusterExtensionFailedToDelete,

    [Description("UpgradeComplete")]
    UpgradeComplete,

    [Description("UpgradeFailed")]
    UpgradeFailed,

    [Description("UpgradePrerequisitesCompleted")]
    UpgradePrerequisitesCompleted,

    [Description("UpgradingKVAIO")]
    UpgradingKVAIO,

    [Description("Validating")]
    Validating,

    [Description("WaitingForCloudOperator")]
    WaitingForCloudOperator,

    [Description("WaitingForHeartbeat")]
    WaitingForHeartbeat,

    [Description("WaitingForKVAIO")]
    WaitingForKVAIO,
}
