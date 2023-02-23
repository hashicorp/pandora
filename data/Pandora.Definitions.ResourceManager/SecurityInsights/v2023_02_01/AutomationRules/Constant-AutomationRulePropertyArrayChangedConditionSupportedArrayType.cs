using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationRulePropertyArrayChangedConditionSupportedArrayTypeConstant
{
    [Description("Alerts")]
    Alerts,

    [Description("Comments")]
    Comments,

    [Description("Labels")]
    Labels,

    [Description("Tactics")]
    Tactics,
}
