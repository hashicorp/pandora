using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.BackupPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RetentionScheduleFormatConstant
{
    [Description("Daily")]
    Daily,

    [Description("Invalid")]
    Invalid,

    [Description("Weekly")]
    Weekly,
}
