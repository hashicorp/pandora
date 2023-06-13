using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.SyncMembers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SyncMemberStateConstant
{
    [Description("DeProvisionFailed")]
    DeProvisionFailed,

    [Description("DeProvisioned")]
    DeProvisioned,

    [Description("DeProvisioning")]
    DeProvisioning,

    [Description("DisabledBackupRestore")]
    DisabledBackupRestore,

    [Description("DisabledTombstoneCleanup")]
    DisabledTombstoneCleanup,

    [Description("ProvisionFailed")]
    ProvisionFailed,

    [Description("Provisioned")]
    Provisioned,

    [Description("Provisioning")]
    Provisioning,

    [Description("ReprovisionFailed")]
    ReprovisionFailed,

    [Description("Reprovisioning")]
    Reprovisioning,

    [Description("SyncCancelled")]
    SyncCancelled,

    [Description("SyncCancelling")]
    SyncCancelling,

    [Description("SyncFailed")]
    SyncFailed,

    [Description("SyncInProgress")]
    SyncInProgress,

    [Description("SyncSucceeded")]
    SyncSucceeded,

    [Description("SyncSucceededWithWarnings")]
    SyncSucceededWithWarnings,

    [Description("UnProvisioned")]
    UnProvisioned,

    [Description("UnReprovisioned")]
    UnReprovisioned,
}
