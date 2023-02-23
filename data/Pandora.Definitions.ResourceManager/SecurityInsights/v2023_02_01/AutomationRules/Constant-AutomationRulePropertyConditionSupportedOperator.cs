using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationRulePropertyConditionSupportedOperatorConstant
{
    [Description("Contains")]
    Contains,

    [Description("EndsWith")]
    EndsWith,

    [Description("Equals")]
    Equals,

    [Description("NotContains")]
    NotContains,

    [Description("NotEndsWith")]
    NotEndsWith,

    [Description("NotEquals")]
    NotEquals,

    [Description("NotStartsWith")]
    NotStartsWith,

    [Description("StartsWith")]
    StartsWith,
}
