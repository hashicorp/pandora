using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.IncidentEntities;

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
