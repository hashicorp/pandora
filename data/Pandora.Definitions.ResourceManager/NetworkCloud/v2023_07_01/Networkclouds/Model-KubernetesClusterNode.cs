using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class KubernetesClusterNodeModel
{
    [JsonPropertyName("agentPoolId")]
    public string? AgentPoolId { get; set; }

    [JsonPropertyName("availabilityZone")]
    public CustomTypes.Zone? AvailabilityZone { get; set; }

    [JsonPropertyName("bareMetalMachineId")]
    public string? BareMetalMachineId { get; set; }

    [JsonPropertyName("cpuCores")]
    public int? CpuCores { get; set; }

    [JsonPropertyName("detailedStatus")]
    public KubernetesClusterNodeDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("diskSizeGB")]
    public int? DiskSizeGB { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("kubernetesVersion")]
    public string? KubernetesVersion { get; set; }

    [JsonPropertyName("labels")]
    public List<KubernetesLabelModel>? Labels { get; set; }

    [JsonPropertyName("memorySizeGB")]
    public int? MemorySizeGB { get; set; }

    [JsonPropertyName("mode")]
    public AgentPoolModeConstant? Mode { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("networkAttachments")]
    public List<NetworkAttachmentModel>? NetworkAttachments { get; set; }

    [JsonPropertyName("powerState")]
    public KubernetesNodePowerStateConstant? PowerState { get; set; }

    [JsonPropertyName("role")]
    public KubernetesNodeRoleConstant? Role { get; set; }

    [JsonPropertyName("taints")]
    public List<KubernetesLabelModel>? Taints { get; set; }

    [JsonPropertyName("vmSkuName")]
    public string? VMSkuName { get; set; }
}
