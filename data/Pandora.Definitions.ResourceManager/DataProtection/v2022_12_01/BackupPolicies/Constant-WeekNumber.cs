using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WeekNumberConstant
{
    [Description("First")]
    First,

    [Description("Fourth")]
    Fourth,

    [Description("Last")]
    Last,

    [Description("Second")]
    Second,

    [Description("Third")]
    Third,
}
