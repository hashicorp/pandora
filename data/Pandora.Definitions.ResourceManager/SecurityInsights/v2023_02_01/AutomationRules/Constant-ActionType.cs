using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionTypeConstant
{
    [Description("ModifyProperties")]
    ModifyProperties,

    [Description("RunPlaybook")]
    RunPlaybook,
}
