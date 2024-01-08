using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.BackupProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LastBackupStatusConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("IRPending")]
    IRPending,

    [Description("Invalid")]
    Invalid,

    [Description("Unhealthy")]
    Unhealthy,
}
