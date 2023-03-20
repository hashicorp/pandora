using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Registries;


internal class RunPropertiesModel
{
    [JsonPropertyName("agentConfiguration")]
    public AgentPropertiesModel? AgentConfiguration { get; set; }

    [JsonPropertyName("agentPoolName")]
    public string? AgentPoolName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createTime")]
    public DateTime? CreateTime { get; set; }

    [JsonPropertyName("customRegistries")]
    public List<string>? CustomRegistries { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("finishTime")]
    public DateTime? FinishTime { get; set; }

    [JsonPropertyName("imageUpdateTrigger")]
    public ImageUpdateTriggerModel? ImageUpdateTrigger { get; set; }

    [JsonPropertyName("isArchiveEnabled")]
    public bool? IsArchiveEnabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTime")]
    public DateTime? LastUpdatedTime { get; set; }

    [JsonPropertyName("logArtifact")]
    public ImageDescriptorModel? LogArtifact { get; set; }

    [JsonPropertyName("outputImages")]
    public List<ImageDescriptorModel>? OutputImages { get; set; }

    [JsonPropertyName("platform")]
    public PlatformPropertiesModel? Platform { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("runErrorMessage")]
    public string? RunErrorMessage { get; set; }

    [JsonPropertyName("runId")]
    public string? RunId { get; set; }

    [JsonPropertyName("runType")]
    public RunTypeConstant? RunType { get; set; }

    [JsonPropertyName("sourceRegistryAuth")]
    public string? SourceRegistryAuth { get; set; }

    [JsonPropertyName("sourceTrigger")]
    public SourceTriggerDescriptorModel? SourceTrigger { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public RunStatusConstant? Status { get; set; }

    [JsonPropertyName("task")]
    public string? Task { get; set; }

    [JsonPropertyName("timerTrigger")]
    public TimerTriggerDescriptorModel? TimerTrigger { get; set; }

    [JsonPropertyName("updateTriggerToken")]
    public string? UpdateTriggerToken { get; set; }
}
