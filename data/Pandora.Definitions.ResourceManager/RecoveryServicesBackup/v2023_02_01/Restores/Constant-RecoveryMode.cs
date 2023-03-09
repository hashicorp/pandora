using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.Restores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryModeConstant
{
    [Description("FileRecovery")]
    FileRecovery,

    [Description("Invalid")]
    Invalid,

    [Description("WorkloadRecovery")]
    WorkloadRecovery,
}
