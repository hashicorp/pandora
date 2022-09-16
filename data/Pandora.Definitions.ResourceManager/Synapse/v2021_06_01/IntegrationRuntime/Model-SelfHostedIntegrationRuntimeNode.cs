using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;


internal class SelfHostedIntegrationRuntimeNodeModel
{
    [JsonPropertyName("capabilities")]
    public Dictionary<string, string>? Capabilities { get; set; }

    [JsonPropertyName("concurrentJobsLimit")]
    public int? ConcurrentJobsLimit { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expiryTime")]
    public DateTime? ExpiryTime { get; set; }

    [JsonPropertyName("hostServiceUri")]
    public string? HostServiceUri { get; set; }

    [JsonPropertyName("isActiveDispatcher")]
    public bool? IsActiveDispatcher { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastConnectTime")]
    public DateTime? LastConnectTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastEndUpdateTime")]
    public DateTime? LastEndUpdateTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStartTime")]
    public DateTime? LastStartTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStartUpdateTime")]
    public DateTime? LastStartUpdateTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStopTime")]
    public DateTime? LastStopTime { get; set; }

    [JsonPropertyName("lastUpdateResult")]
    public IntegrationRuntimeUpdateResultConstant? LastUpdateResult { get; set; }

    [JsonPropertyName("machineName")]
    public string? MachineName { get; set; }

    [JsonPropertyName("maxConcurrentJobs")]
    public int? MaxConcurrentJobs { get; set; }

    [JsonPropertyName("nodeName")]
    public string? NodeName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("registerTime")]
    public DateTime? RegisterTime { get; set; }

    [JsonPropertyName("status")]
    public SelfHostedIntegrationRuntimeNodeStatusConstant? Status { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("versionStatus")]
    public string? VersionStatus { get; set; }
}
