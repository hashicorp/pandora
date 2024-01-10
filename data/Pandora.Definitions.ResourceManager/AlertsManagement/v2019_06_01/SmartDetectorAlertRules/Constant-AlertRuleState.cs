using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_06_01.SmartDetectorAlertRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertRuleStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
