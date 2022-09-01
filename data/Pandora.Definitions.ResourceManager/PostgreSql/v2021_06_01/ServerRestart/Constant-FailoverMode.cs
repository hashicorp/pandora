using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2021_06_01.ServerRestart;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FailoverModeConstant
{
    [Description("ForcedFailover")]
    ForcedFailover,

    [Description("ForcedSwitchover")]
    ForcedSwitchover,

    [Description("PlannedFailover")]
    PlannedFailover,

    [Description("PlannedSwitchover")]
    PlannedSwitchover,
}
