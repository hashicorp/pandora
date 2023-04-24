using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25.GuestConfigurationAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssignmentTypeConstant
{
    [Description("ApplyAndAutoCorrect")]
    ApplyAndAutoCorrect,

    [Description("ApplyAndMonitor")]
    ApplyAndMonitor,

    [Description("Audit")]
    Audit,

    [Description("DeployAndAutoCorrect")]
    DeployAndAutoCorrect,
}
