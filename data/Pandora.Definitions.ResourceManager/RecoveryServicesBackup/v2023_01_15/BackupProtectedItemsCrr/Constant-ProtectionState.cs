using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.BackupProtectedItemsCrr;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtectionStateConstant
{
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
