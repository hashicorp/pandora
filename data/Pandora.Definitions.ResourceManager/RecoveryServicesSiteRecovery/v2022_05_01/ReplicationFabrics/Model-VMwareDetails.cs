using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationFabrics;

[ValueForType("VMware")]
internal class VMwareDetailsModel : FabricSpecificDetailsModel
{
    [JsonPropertyName("agentCount")]
    public string? AgentCount { get; set; }

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

    [JsonPropertyName("csServiceStatus")]
    public string? CsServiceStatus { get; set; }

    [JsonPropertyName("databaseServerLoad")]
    public string? DatabaseServerLoad { get; set; }

    [JsonPropertyName("databaseServerLoadStatus")]
    public string? DatabaseServerLoadStatus { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeat")]
    public DateTime? LastHeartbeat { get; set; }

    [JsonPropertyName("masterTargetServers")]
    public List<MasterTargetServerModel>? MasterTargetServers { get; set; }

    [JsonPropertyName("memoryUsageStatus")]
    public string? MemoryUsageStatus { get; set; }

    [JsonPropertyName("processServerCount")]
    public string? ProcessServerCount { get; set; }

    [JsonPropertyName("processServers")]
    public List<ProcessServerModel>? ProcessServers { get; set; }

    [JsonPropertyName("protectedServers")]
    public string? ProtectedServers { get; set; }

    [JsonPropertyName("psTemplateVersion")]
    public string? PsTemplateVersion { get; set; }

    [JsonPropertyName("replicationPairCount")]
    public string? ReplicationPairCount { get; set; }

    [JsonPropertyName("runAsAccounts")]
    public List<RunAsAccountModel>? RunAsAccounts { get; set; }

    [JsonPropertyName("spaceUsageStatus")]
    public string? SpaceUsageStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sslCertExpiryDate")]
    public DateTime? SslCertExpiryDate { get; set; }

    [JsonPropertyName("sslCertExpiryRemainingDays")]
    public int? SslCertExpiryRemainingDays { get; set; }

    [JsonPropertyName("switchProviderBlockingErrorDetails")]
    public List<InMageFabricSwitchProviderBlockingErrorDetailsModel>? SwitchProviderBlockingErrorDetails { get; set; }

    [JsonPropertyName("systemLoad")]
    public string? SystemLoad { get; set; }

    [JsonPropertyName("systemLoadStatus")]
    public string? SystemLoadStatus { get; set; }

    [JsonPropertyName("totalMemoryInBytes")]
    public int? TotalMemoryInBytes { get; set; }

    [JsonPropertyName("totalSpaceInBytes")]
    public int? TotalSpaceInBytes { get; set; }

    [JsonPropertyName("versionStatus")]
    public string? VersionStatus { get; set; }

    [JsonPropertyName("webLoad")]
    public string? WebLoad { get; set; }

    [JsonPropertyName("webLoadStatus")]
    public string? WebLoadStatus { get; set; }
}
