using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TestMigrationStateConstant
{
    [Description("None")]
    None,

    [Description("TestMigrationCleanupInProgress")]
    TestMigrationCleanupInProgress,

    [Description("TestMigrationCompletedWithInformation")]
    TestMigrationCompletedWithInformation,

    [Description("TestMigrationFailed")]
    TestMigrationFailed,

    [Description("TestMigrationInProgress")]
    TestMigrationInProgress,

    [Description("TestMigrationPartiallySucceeded")]
    TestMigrationPartiallySucceeded,

    [Description("TestMigrationSucceeded")]
    TestMigrationSucceeded,
}
