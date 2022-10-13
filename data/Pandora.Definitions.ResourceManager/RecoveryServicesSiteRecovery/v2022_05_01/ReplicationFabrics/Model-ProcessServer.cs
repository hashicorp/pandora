using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationFabrics;


internal class ProcessServerModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("agentExpiryDate")]
    public DateTime? AgentExpiryDate { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("agentVersionDetails")]
    public VersionDetailsModel? AgentVersionDetails { get; set; }

    [JsonPropertyName("availableMemoryInBytes")]
    public int? AvailableMemoryInBytes { get; set; }

    [JsonPropertyName("availableSpaceInBytes")]
    public int? AvailableSpaceInBytes { get; set; }

    [JsonPropertyName("cpuLoad")]
    public string? CpuLoad { get; set; }

    [JsonPropertyName("cpuLoadStatus")]
    public string? CpuLoadStatus { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("health")]
    public ProtectionHealthConstant? Health { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [JsonPropertyName("hostId")]
    public string? HostId { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeat")]
    public DateTime? LastHeartbeat { get; set; }

    [JsonPropertyName("machineCount")]
    public string? MachineCount { get; set; }

    [JsonPropertyName("marsCommunicationStatus")]
    public string? MarsCommunicationStatus { get; set; }

    [JsonPropertyName("marsRegistrationStatus")]
    public string? MarsRegistrationStatus { get; set; }

    [JsonPropertyName("memoryUsageStatus")]
    public string? MemoryUsageStatus { get; set; }

    [JsonPropertyName("mobilityServiceUpdates")]
    public List<MobilityServiceUpdateModel>? MobilityServiceUpdates { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("psServiceStatus")]
    public string? PsServiceStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("psStatsRefreshTime")]
    public DateTime? PsStatsRefreshTime { get; set; }

    [JsonPropertyName("replicationPairCount")]
    public string? ReplicationPairCount { get; set; }

    [JsonPropertyName("spaceUsageStatus")]
    public string? SpaceUsageStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sslCertExpiryDate")]
    public DateTime? SslCertExpiryDate { get; set; }

    [JsonPropertyName("sslCertExpiryRemainingDays")]
    public int? SslCertExpiryRemainingDays { get; set; }

    [JsonPropertyName("systemLoad")]
    public string? SystemLoad { get; set; }

    [JsonPropertyName("systemLoadStatus")]
    public string? SystemLoadStatus { get; set; }

    [JsonPropertyName("throughputInBytes")]
    public int? ThroughputInBytes { get; set; }

    [JsonPropertyName("throughputInMBps")]
    public int? ThroughputInMBps { get; set; }

    [JsonPropertyName("throughputStatus")]
    public string? ThroughputStatus { get; set; }

    [JsonPropertyName("throughputUploadPendingDataInBytes")]
    public int? ThroughputUploadPendingDataInBytes { get; set; }

    [JsonPropertyName("totalMemoryInBytes")]
    public int? TotalMemoryInBytes { get; set; }

    [JsonPropertyName("totalSpaceInBytes")]
    public int? TotalSpaceInBytes { get; set; }

    [JsonPropertyName("versionStatus")]
    public string? VersionStatus { get; set; }
}
