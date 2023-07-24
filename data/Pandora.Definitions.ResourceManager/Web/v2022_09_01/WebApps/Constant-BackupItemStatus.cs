using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackupItemStatusConstant
{
    [Description("Created")]
    Created,

    [Description("DeleteFailed")]
    DeleteFailed,

    [Description("DeleteInProgress")]
    DeleteInProgress,

    [Description("Deleted")]
    Deleted,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("PartiallySucceeded")]
    PartiallySucceeded,

    [Description("Skipped")]
    Skipped,

    [Description("Succeeded")]
    Succeeded,

    [Description("TimedOut")]
    TimedOut,
}
