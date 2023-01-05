using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AbsoluteMarkerConstant
{
    [Description("AllBackup")]
    AllBackup,

    [Description("FirstOfDay")]
    FirstOfDay,

    [Description("FirstOfMonth")]
    FirstOfMonth,

    [Description("FirstOfWeek")]
    FirstOfWeek,

    [Description("FirstOfYear")]
    FirstOfYear,
}
