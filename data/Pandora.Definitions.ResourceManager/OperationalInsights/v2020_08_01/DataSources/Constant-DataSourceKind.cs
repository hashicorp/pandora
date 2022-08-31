using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.DataSources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataSourceKindConstant
{
    [Description("ApplicationInsights")]
    ApplicationInsights,

    [Description("AzureActivityLog")]
    AzureActivityLog,

    [Description("AzureAuditLog")]
    AzureAuditLog,

    [Description("ChangeTrackingContentLocation")]
    ChangeTrackingContentLocation,

    [Description("ChangeTrackingCustomPath")]
    ChangeTrackingCustomPath,

    [Description("ChangeTrackingDataTypeConfiguration")]
    ChangeTrackingDataTypeConfiguration,

    [Description("ChangeTrackingDefaultRegistry")]
    ChangeTrackingDefaultRegistry,

    [Description("ChangeTrackingLinuxPath")]
    ChangeTrackingLinuxPath,

    [Description("ChangeTrackingPath")]
    ChangeTrackingPath,

    [Description("ChangeTrackingRegistry")]
    ChangeTrackingRegistry,

    [Description("ChangeTrackingServices")]
    ChangeTrackingServices,

    [Description("CustomLog")]
    CustomLog,

    [Description("CustomLogCollection")]
    CustomLogCollection,

    [Description("DnsAnalytics")]
    DnsAnalytics,

    [Description("GenericDataSource")]
    GenericDataSource,

    [Description("IISLogs")]
    IISLogs,

    [Description("ImportComputerGroup")]
    ImportComputerGroup,

    [Description("Itsm")]
    Itsm,

    [Description("LinuxChangeTrackingPath")]
    LinuxChangeTrackingPath,

    [Description("LinuxPerformanceCollection")]
    LinuxPerformanceCollection,

    [Description("LinuxPerformanceObject")]
    LinuxPerformanceObject,

    [Description("LinuxSyslog")]
    LinuxSyslog,

    [Description("LinuxSyslogCollection")]
    LinuxSyslogCollection,

    [Description("NetworkMonitoring")]
    NetworkMonitoring,

    [Description("Office365")]
    OfficeThreeSixFive,

    [Description("SecurityCenterSecurityWindowsBaselineConfiguration")]
    SecurityCenterSecurityWindowsBaselineConfiguration,

    [Description("SecurityEventCollectionConfiguration")]
    SecurityEventCollectionConfiguration,

    [Description("SecurityInsightsSecurityEventCollectionConfiguration")]
    SecurityInsightsSecurityEventCollectionConfiguration,

    [Description("SecurityWindowsBaselineConfiguration")]
    SecurityWindowsBaselineConfiguration,

    [Description("SqlDataClassification")]
    SqlDataClassification,

    [Description("WindowsEvent")]
    WindowsEvent,

    [Description("WindowsPerformanceCounter")]
    WindowsPerformanceCounter,

    [Description("WindowsTelemetry")]
    WindowsTelemetry,
}
