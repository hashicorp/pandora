using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertsManagement;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FieldConstant
{
    [Description("AlertContext")]
    AlertContext,

    [Description("AlertRuleId")]
    AlertRuleId,

    [Description("AlertRuleName")]
    AlertRuleName,

    [Description("Description")]
    Description,

    [Description("MonitorCondition")]
    MonitorCondition,

    [Description("MonitorService")]
    MonitorService,

    [Description("Severity")]
    Severity,

    [Description("SignalType")]
    SignalType,

    [Description("TargetResource")]
    TargetResource,

    [Description("TargetResourceGroup")]
    TargetResourceGroup,

    [Description("TargetResourceType")]
    TargetResourceType,
}
