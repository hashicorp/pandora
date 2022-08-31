using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CurrentProtectionStateConstant
{
    [Description("BackupSchedulesSuspended")]
    BackupSchedulesSuspended,

    [Description("ConfiguringProtection")]
    ConfiguringProtection,

    [Description("ConfiguringProtectionFailed")]
    ConfiguringProtectionFailed,

    [Description("Invalid")]
    Invalid,

    [Description("NotProtected")]
    NotProtected,

    [Description("ProtectionConfigured")]
    ProtectionConfigured,

    [Description("ProtectionError")]
    ProtectionError,

    [Description("ProtectionStopped")]
    ProtectionStopped,

    [Description("RetentionSchedulesSuspended")]
    RetentionSchedulesSuspended,

    [Description("SoftDeleted")]
    SoftDeleted,

    [Description("SoftDeleting")]
    SoftDeleting,

    [Description("UpdatingProtection")]
    UpdatingProtection,
}
