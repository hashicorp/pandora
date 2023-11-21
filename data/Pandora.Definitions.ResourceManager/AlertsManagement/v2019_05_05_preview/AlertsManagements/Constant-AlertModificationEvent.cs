using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertModificationEventConstant
{
    [Description("ActionRuleSuppressed")]
    ActionRuleSuppressed,

    [Description("ActionRuleTriggered")]
    ActionRuleTriggered,

    [Description("ActionsFailed")]
    ActionsFailed,

    [Description("ActionsSuppressed")]
    ActionsSuppressed,

    [Description("ActionsTriggered")]
    ActionsTriggered,

    [Description("AlertCreated")]
    AlertCreated,

    [Description("MonitorConditionChange")]
    MonitorConditionChange,

    [Description("SeverityChange")]
    SeverityChange,

    [Description("StateChange")]
    StateChange,
}
