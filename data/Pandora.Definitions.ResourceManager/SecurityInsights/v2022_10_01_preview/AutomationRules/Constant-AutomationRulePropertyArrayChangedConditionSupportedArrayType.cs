using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.AutomationRules;

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
