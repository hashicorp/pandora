using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationFabrics;


internal class MasterTargetServerModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("agentExpiryDate")]
    public DateTime? AgentExpiryDate { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("agentVersionDetails")]
    public VersionDetailsModel? AgentVersionDetails { get; set; }

    [JsonPropertyName("dataStores")]
    public List<DataStoreModel>? DataStores { get; set; }

    [JsonPropertyName("diskCount")]
    public int? DiskCount { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeat")]
    public DateTime? LastHeartbeat { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("marsAgentExpiryDate")]
    public DateTime? MarsAgentExpiryDate { get; set; }

    [JsonPropertyName("marsAgentVersion")]
    public string? MarsAgentVersion { get; set; }

    [JsonPropertyName("marsAgentVersionDetails")]
    public VersionDetailsModel? MarsAgentVersionDetails { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("retentionVolumes")]
    public List<RetentionVolumeModel>? RetentionVolumes { get; set; }

    [JsonPropertyName("validationErrors")]
    public List<HealthErrorModel>? ValidationErrors { get; set; }

    [JsonPropertyName("versionStatus")]
    public string? VersionStatus { get; set; }
}
