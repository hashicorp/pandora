using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IncidentStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Closed")]
    Closed,

    [Description("New")]
    New,
}
