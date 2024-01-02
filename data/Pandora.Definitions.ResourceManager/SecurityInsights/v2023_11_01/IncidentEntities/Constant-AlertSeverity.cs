using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.IncidentEntities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertSeverityConstant
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
