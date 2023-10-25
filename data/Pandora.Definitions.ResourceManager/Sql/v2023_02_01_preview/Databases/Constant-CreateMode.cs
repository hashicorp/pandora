using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateModeConstant
{
    [Description("Copy")]
    Copy,

    [Description("Default")]
    Default,

    [Description("OnlineSecondary")]
    OnlineSecondary,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,

    [Description("Recovery")]
    Recovery,

    [Description("Restore")]
    Restore,

    [Description("RestoreExternalBackup")]
    RestoreExternalBackup,

    [Description("RestoreExternalBackupSecondary")]
    RestoreExternalBackupSecondary,

    [Description("RestoreLongTermRetentionBackup")]
    RestoreLongTermRetentionBackup,

    [Description("Secondary")]
    Secondary,
}
