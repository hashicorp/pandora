using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dynatrace.v2023_04_27.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateStatusConstant
{
    [Description("INCOMPATIBLE")]
    INCOMPATIBLE,

    [Description("OUTDATED")]
    OUTDATED,

    [Description("SCHEDULED")]
    SCHEDULED,

    [Description("SUPPRESSED")]
    SUPPRESSED,

    [Description("UNKNOWN")]
    UNKNOWN,

    [Description("UPDATE_IN_PROGRESS")]
    UPDATEINPROGRESS,

    [Description("UPDATE_PENDING")]
    UPDATEPENDING,

    [Description("UPDATE_PROBLEM")]
    UPDATEPROBLEM,

    [Description("UP2DATE")]
    UPTwoDATE,
}
