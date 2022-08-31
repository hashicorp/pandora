using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.BackupVaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceMoveStateConstant
{
    [Description("CommitFailed")]
    CommitFailed,

    [Description("CommitTimedout")]
    CommitTimedout,

    [Description("CriticalFailure")]
    CriticalFailure,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("MoveSucceeded")]
    MoveSucceeded,

    [Description("PartialSuccess")]
    PartialSuccess,

    [Description("PrepareFailed")]
    PrepareFailed,

    [Description("PrepareTimedout")]
    PrepareTimedout,

    [Description("Unknown")]
    Unknown,
}
