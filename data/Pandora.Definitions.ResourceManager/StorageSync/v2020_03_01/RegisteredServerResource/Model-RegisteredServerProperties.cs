using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.RegisteredServerResource;


internal class RegisteredServerPropertiesModel
{
    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("agentVersionExpirationDate")]
    public DateTime? AgentVersionExpirationDate { get; set; }

    [JsonPropertyName("agentVersionStatus")]
    public RegisteredServerAgentVersionStatusConstant? AgentVersionStatus { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("clusterName")]
    public string? ClusterName { get; set; }

    [JsonPropertyName("discoveryEndpointUri")]
    public string? DiscoveryEndpointUri { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("lastHeartBeat")]
    public string? LastHeartBeat { get; set; }

    [JsonPropertyName("lastOperationName")]
    public string? LastOperationName { get; set; }

    [JsonPropertyName("lastWorkflowId")]
    public string? LastWorkflowId { get; set; }

    [JsonPropertyName("managementEndpointUri")]
    public string? ManagementEndpointUri { get; set; }

    [JsonPropertyName("monitoringConfiguration")]
    public string? MonitoringConfiguration { get; set; }

    [JsonPropertyName("monitoringEndpointUri")]
    public string? MonitoringEndpointUri { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceLocation")]
    public string? ResourceLocation { get; set; }

    [JsonPropertyName("serverCertificate")]
    public string? ServerCertificate { get; set; }

    [JsonPropertyName("serverId")]
    public string? ServerId { get; set; }

    [JsonPropertyName("serverManagementErrorCode")]
    public int? ServerManagementErrorCode { get; set; }

    [JsonPropertyName("serverOSVersion")]
    public string? ServerOSVersion { get; set; }

    [JsonPropertyName("serverRole")]
    public string? ServerRole { get; set; }

    [JsonPropertyName("serviceLocation")]
    public string? ServiceLocation { get; set; }

    [JsonPropertyName("storageSyncServiceUid")]
    public string? StorageSyncServiceUid { get; set; }
}
