using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.IncidentBookmarks;

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
