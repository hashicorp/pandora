using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtectedItemStateConstant
{
    [Description("BackupsSuspended")]
    BackupsSuspended,

    [Description("IRPending")]
    IRPending,

    [Description("Invalid")]
    Invalid,

    [Description("Protected")]
    Protected,

    [Description("ProtectionError")]
    ProtectionError,

    [Description("ProtectionPaused")]
    ProtectionPaused,

    [Description("ProtectionStopped")]
    ProtectionStopped,
}
