using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;


internal class DataSourcesSpecModel
{
    [JsonPropertyName("dataImports")]
    public DataImportSourcesModel? DataImports { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionDataSourceModel>? Extensions { get; set; }

    [JsonPropertyName("iisLogs")]
    public List<IisLogsDataSourceModel>? IisLogs { get; set; }

    [JsonPropertyName("logFiles")]
    public List<LogFilesDataSourceModel>? LogFiles { get; set; }

    [JsonPropertyName("performanceCounters")]
    public List<PerfCounterDataSourceModel>? PerformanceCounters { get; set; }

    [JsonPropertyName("platformTelemetry")]
    public List<PlatformTelemetryDataSourceModel>? PlatformTelemetry { get; set; }

    [JsonPropertyName("prometheusForwarder")]
    public List<PrometheusForwarderDataSourceModel>? PrometheusForwarder { get; set; }

    [JsonPropertyName("syslog")]
    public List<SyslogDataSourceModel>? Syslog { get; set; }

    [JsonPropertyName("windowsEventLogs")]
    public List<WindowsEventLogDataSourceModel>? WindowsEventLogs { get; set; }

    [JsonPropertyName("windowsFirewallLogs")]
    public List<WindowsFirewallLogsDataSourceModel>? WindowsFirewallLogs { get; set; }
}
