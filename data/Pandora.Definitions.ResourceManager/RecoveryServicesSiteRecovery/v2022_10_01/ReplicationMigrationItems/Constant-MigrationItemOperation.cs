using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationItemOperationConstant
{
    [Description("DisableMigration")]
    DisableMigration,

    [Description("Migrate")]
    Migrate,

    [Description("PauseReplication")]
    PauseReplication,

    [Description("ResumeReplication")]
    ResumeReplication,

    [Description("StartResync")]
    StartResync,

    [Description("TestMigrate")]
    TestMigrate,

    [Description("TestMigrateCleanup")]
    TestMigrateCleanup,
}
