using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class AgentPoolPropertiesModel
{
    [JsonPropertyName("administratorConfiguration")]
    public AdministratorConfigurationModel? AdministratorConfiguration { get; set; }

    [JsonPropertyName("agentOptions")]
    public AgentOptionsModel? AgentOptions { get; set; }

    [JsonPropertyName("attachedNetworkConfiguration")]
    public AttachedNetworkConfigurationModel? AttachedNetworkConfiguration { get; set; }

    [JsonPropertyName("availabilityZones")]
    public CustomTypes.Zones? AvailabilityZones { get; set; }

    [JsonPropertyName("count")]
    [Required]
    public int Count { get; set; }

    [JsonPropertyName("detailedStatus")]
    public AgentPoolDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("kubernetesVersion")]
    public string? KubernetesVersion { get; set; }

    [JsonPropertyName("labels")]
    public List<KubernetesLabelModel>? Labels { get; set; }

    [JsonPropertyName("mode")]
    [Required]
    public AgentPoolModeConstant Mode { get; set; }

    [JsonPropertyName("provisioningState")]
    public AgentPoolProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("taints")]
    public List<KubernetesLabelModel>? Taints { get; set; }

    [JsonPropertyName("upgradeSettings")]
    public AgentPoolUpgradeSettingsModel? UpgradeSettings { get; set; }

    [JsonPropertyName("vmSkuName")]
    [Required]
    public string VMSkuName { get; set; }
}
