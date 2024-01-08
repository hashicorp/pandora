using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.IncidentAlerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfidenceScoreStatusConstant
{
    [Description("Final")]
    Final,

    [Description("InProcess")]
    InProcess,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("NotFinal")]
    NotFinal,
}
