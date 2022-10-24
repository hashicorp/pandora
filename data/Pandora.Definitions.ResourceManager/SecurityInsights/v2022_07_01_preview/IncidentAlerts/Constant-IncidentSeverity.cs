using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.IncidentAlerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IncidentSeverityConstant
{
    [Description("High")]
    High,

    [Description("Informational")]
    Informational,

    [Description("Low")]
    Low,

    [Description("Medium")]
    Medium,
}
