using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.IncidentAlerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfidenceLevelConstant
{
    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Unknown")]
    Unknown,
}
