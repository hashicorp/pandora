using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.ProtectionPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WeekOfMonthConstant
{
    [Description("First")]
    First,

    [Description("Fourth")]
    Fourth,

    [Description("Invalid")]
    Invalid,

    [Description("Last")]
    Last,

    [Description("Second")]
    Second,

    [Description("Third")]
    Third,
}
