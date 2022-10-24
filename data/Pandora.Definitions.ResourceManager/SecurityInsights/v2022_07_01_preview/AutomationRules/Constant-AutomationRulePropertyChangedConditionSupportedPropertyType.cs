using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationRulePropertyChangedConditionSupportedPropertyTypeConstant
{
    [Description("IncidentOwner")]
    IncidentOwner,

    [Description("IncidentSeverity")]
    IncidentSeverity,

    [Description("IncidentStatus")]
    IncidentStatus,
}
