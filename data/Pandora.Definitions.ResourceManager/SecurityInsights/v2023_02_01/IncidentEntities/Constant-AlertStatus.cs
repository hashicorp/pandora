using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.IncidentEntities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertStatusConstant
{
    [Description("Dismissed")]
    Dismissed,

    [Description("InProgress")]
    InProgress,

    [Description("New")]
    New,

    [Description("Resolved")]
    Resolved,

    [Description("Unknown")]
    Unknown,
}
