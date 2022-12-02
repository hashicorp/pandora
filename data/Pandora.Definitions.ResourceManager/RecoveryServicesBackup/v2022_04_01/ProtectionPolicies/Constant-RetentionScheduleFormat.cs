using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.ProtectionPolicies;

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
