using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationStateConstant
{
    [Description("DisableMigrationFailed")]
    DisableMigrationFailed,

    [Description("DisableMigrationInProgress")]
    DisableMigrationInProgress,

    [Description("EnableMigrationFailed")]
    EnableMigrationFailed,

    [Description("EnableMigrationInProgress")]
    EnableMigrationInProgress,

    [Description("InitialSeedingFailed")]
    InitialSeedingFailed,

    [Description("InitialSeedingInProgress")]
    InitialSeedingInProgress,

    [Description("MigrationCompletedWithInformation")]
    MigrationCompletedWithInformation,

    [Description("MigrationFailed")]
    MigrationFailed,

    [Description("MigrationInProgress")]
    MigrationInProgress,

    [Description("MigrationPartiallySucceeded")]
    MigrationPartiallySucceeded,

    [Description("MigrationSucceeded")]
    MigrationSucceeded,

    [Description("None")]
    None,

    [Description("ProtectionSuspended")]
    ProtectionSuspended,

    [Description("Replicating")]
    Replicating,

    [Description("ResumeInProgress")]
    ResumeInProgress,

    [Description("ResumeInitiated")]
    ResumeInitiated,

    [Description("SuspendingProtection")]
    SuspendingProtection,
}
