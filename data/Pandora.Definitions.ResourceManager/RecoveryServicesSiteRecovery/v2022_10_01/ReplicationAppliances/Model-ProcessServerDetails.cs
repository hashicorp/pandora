using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationAppliances;


internal class ProcessServerDetailsModel
{
    [JsonPropertyName("availableMemoryInBytes")]
    public int? AvailableMemoryInBytes { get; set; }

    [JsonPropertyName("availableSpaceInBytes")]
    public int? AvailableSpaceInBytes { get; set; }

    [JsonPropertyName("biosId")]
    public string? BiosId { get; set; }

    [JsonPropertyName("diskUsageStatus")]
    public RcmComponentStatusConstant? DiskUsageStatus { get; set; }

    [JsonPropertyName("fabricObjectId")]
    public string? FabricObjectId { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("freeSpacePercentage")]
    public float? FreeSpacePercentage { get; set; }

    [JsonPropertyName("health")]
    public ProtectionHealthConstant? Health { get; set; }

    [JsonPropertyName("healthErrors")]
    public List<HealthErrorModel>? HealthErrors { get; set; }

    [JsonPropertyName("historicHealth")]
    public ProtectionHealthConstant? HistoricHealth { get; set; }

    [JsonPropertyName("ipAddresses")]
    public List<string>? IPAddresses { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeatUtc")]
    public DateTime? LastHeartbeatUtc { get; set; }

    [JsonPropertyName("memoryUsagePercentage")]
    public float? MemoryUsagePercentage { get; set; }

    [JsonPropertyName("memoryUsageStatus")]
    public RcmComponentStatusConstant? MemoryUsageStatus { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("processorUsagePercentage")]
    public float? ProcessorUsagePercentage { get; set; }

    [JsonPropertyName("processorUsageStatus")]
    public RcmComponentStatusConstant? ProcessorUsageStatus { get; set; }

    [JsonPropertyName("protectedItemCount")]
    public int? ProtectedItemCount { get; set; }

    [JsonPropertyName("systemLoad")]
    public int? SystemLoad { get; set; }

    [JsonPropertyName("systemLoadStatus")]
    public RcmComponentStatusConstant? SystemLoadStatus { get; set; }

    [JsonPropertyName("throughputInBytes")]
    public int? ThroughputInBytes { get; set; }

    [JsonPropertyName("throughputStatus")]
    public RcmComponentStatusConstant? ThroughputStatus { get; set; }

    [JsonPropertyName("throughputUploadPendingDataInBytes")]
    public int? ThroughputUploadPendingDataInBytes { get; set; }

    [JsonPropertyName("totalMemoryInBytes")]
    public int? TotalMemoryInBytes { get; set; }

    [JsonPropertyName("totalSpaceInBytes")]
    public int? TotalSpaceInBytes { get; set; }

    [JsonPropertyName("usedMemoryInBytes")]
    public int? UsedMemoryInBytes { get; set; }

    [JsonPropertyName("usedSpaceInBytes")]
    public int? UsedSpaceInBytes { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
