using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedDatabases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDatabaseCreateModeConstant
{
    [Description("Default")]
    Default,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,

    [Description("Recovery")]
    Recovery,

    [Description("RestoreExternalBackup")]
    RestoreExternalBackup,

    [Description("RestoreLongTermRetentionBackup")]
    RestoreLongTermRetentionBackup,
}
