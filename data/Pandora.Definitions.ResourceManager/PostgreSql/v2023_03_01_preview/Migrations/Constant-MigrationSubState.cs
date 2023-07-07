using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Migrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MigrationSubStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("CompletingMigration")]
    CompletingMigration,

    [Description("MigratingData")]
    MigratingData,

    [Description("PerformingPreRequisiteSteps")]
    PerformingPreRequisiteSteps,

    [Description("WaitingForCutoverTrigger")]
    WaitingForCutoverTrigger,

    [Description("WaitingForDBsToMigrateSpecification")]
    WaitingForDBsToMigrateSpecification,

    [Description("WaitingForDataMigrationScheduling")]
    WaitingForDataMigrationScheduling,

    [Description("WaitingForDataMigrationWindow")]
    WaitingForDataMigrationWindow,

    [Description("WaitingForLogicalReplicationSetupRequestOnSourceDB")]
    WaitingForLogicalReplicationSetupRequestOnSourceDB,

    [Description("WaitingForTargetDBOverwriteConfirmation")]
    WaitingForTargetDBOverwriteConfirmation,
}
