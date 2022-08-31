using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationRuleActionTypeConstant
{
    [Description("ModifyProperties")]
    ModifyProperties,

    [Description("RunPlaybook")]
    RunPlaybook,
}
