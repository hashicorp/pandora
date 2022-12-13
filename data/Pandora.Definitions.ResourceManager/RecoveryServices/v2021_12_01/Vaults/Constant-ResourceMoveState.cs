using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2021_12_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceMoveStateConstant
{
    [Description("CommitFailed")]
    CommitFailed,

    [Description("CommitTimedout")]
    CommitTimedout,

    [Description("CriticalFailure")]
    CriticalFailure,

    [Description("Failure")]
    Failure,

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
