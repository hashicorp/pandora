using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertsSummaryGroupByFieldsConstant
{
    [Description("alertRule")]
    AlertRule,

    [Description("alertState")]
    AlertState,

    [Description("monitorCondition")]
    MonitorCondition,

    [Description("monitorService")]
    MonitorService,

    [Description("severity")]
    Severity,

    [Description("signalType")]
    SignalType,
}
