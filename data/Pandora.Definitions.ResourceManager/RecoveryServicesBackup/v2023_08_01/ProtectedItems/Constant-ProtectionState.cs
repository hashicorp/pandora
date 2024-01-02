using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.ProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtectionStateConstant
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
