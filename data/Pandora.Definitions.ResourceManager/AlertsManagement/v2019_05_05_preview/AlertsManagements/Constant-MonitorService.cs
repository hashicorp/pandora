using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonitorServiceConstant
{
    [Description("ActivityLog Administrative")]
    ActivityLogAdministrative,

    [Description("ActivityLog Autoscale")]
    ActivityLogAutoscale,

    [Description("ActivityLog Policy")]
    ActivityLogPolicy,

    [Description("ActivityLog Recommendation")]
    ActivityLogRecommendation,

    [Description("ActivityLog Security")]
    ActivityLogSecurity,

    [Description("Application Insights")]
    ApplicationInsights,

    [Description("Log Analytics")]
    LogAnalytics,

    [Description("Nagios")]
    Nagios,

    [Description("Platform")]
    Platform,

    [Description("SCOM")]
    SCOM,

    [Description("ServiceHealth")]
    ServiceHealth,

    [Description("SmartDetector")]
    SmartDetector,

    [Description("VM Insights")]
    VMInsights,

    [Description("Zabbix")]
    Zabbix,
}
