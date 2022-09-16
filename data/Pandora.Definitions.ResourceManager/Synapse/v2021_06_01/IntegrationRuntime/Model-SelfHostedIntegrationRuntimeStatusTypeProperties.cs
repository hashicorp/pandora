using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;


internal class SelfHostedIntegrationRuntimeStatusTypePropertiesModel
{
    [JsonPropertyName("autoUpdate")]
    public IntegrationRuntimeAutoUpdateConstant? AutoUpdate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("autoUpdateETA")]
    public DateTime? AutoUpdateETA { get; set; }

    [JsonPropertyName("capabilities")]
    public Dictionary<string, string>? Capabilities { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createTime")]
    public DateTime? CreateTime { get; set; }

    [JsonPropertyName("internalChannelEncryption")]
    public IntegrationRuntimeInternalChannelEncryptionModeConstant? InternalChannelEncryption { get; set; }

    [JsonPropertyName("latestVersion")]
    public string? LatestVersion { get; set; }

    [JsonPropertyName("links")]
    public List<LinkedIntegrationRuntimeModel>? Links { get; set; }

    [JsonPropertyName("localTimeZoneOffset")]
    public string? LocalTimeZoneOffset { get; set; }

    [JsonPropertyName("nodeCommunicationChannelEncryptionMode")]
    public string? NodeCommunicationChannelEncryptionMode { get; set; }

    [JsonPropertyName("nodes")]
    public List<SelfHostedIntegrationRuntimeNodeModel>? Nodes { get; set; }

    [JsonPropertyName("pushedVersion")]
    public string? PushedVersion { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("scheduledUpdateDate")]
    public DateTime? ScheduledUpdateDate { get; set; }

    [JsonPropertyName("serviceUrls")]
    public List<string>? ServiceUrls { get; set; }

    [JsonPropertyName("taskQueueId")]
    public string? TaskQueueId { get; set; }

    [JsonPropertyName("updateDelayOffset")]
    public string? UpdateDelayOffset { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("versionStatus")]
    public string? VersionStatus { get; set; }
}
