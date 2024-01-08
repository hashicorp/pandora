using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.ValidateOperation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryModeConstant
{
    [Description("FileRecovery")]
    FileRecovery,

    [Description("Invalid")]
    Invalid,

    [Description("RecoveryUsingSnapshot")]
    RecoveryUsingSnapshot,

    [Description("SnapshotAttach")]
    SnapshotAttach,

    [Description("SnapshotAttachAndRecover")]
    SnapshotAttachAndRecover,

    [Description("WorkloadRecovery")]
    WorkloadRecovery,
}
