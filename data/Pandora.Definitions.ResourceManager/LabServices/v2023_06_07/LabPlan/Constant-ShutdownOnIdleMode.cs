using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2023_06_07.LabPlan;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ShutdownOnIdleModeConstant
{
    [Description("LowUsage")]
    LowUsage,

    [Description("None")]
    None,

    [Description("UserAbsence")]
    UserAbsence,
}
