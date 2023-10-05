using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageMover.v2023_10_01.JobDefinitions;


internal class JobDefinitionPropertiesModel
{
    [JsonPropertyName("agentName")]
    public string? AgentName { get; set; }

    [JsonPropertyName("agentResourceId")]
    public string? AgentResourceId { get; set; }

    [JsonPropertyName("copyMode")]
    [Required]
    public CopyModeConstant CopyMode { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("latestJobRunName")]
    public string? LatestJobRunName { get; set; }

    [JsonPropertyName("latestJobRunResourceId")]
    public string? LatestJobRunResourceId { get; set; }

    [JsonPropertyName("latestJobRunStatus")]
    public JobRunStatusConstant? LatestJobRunStatus { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sourceName")]
    [Required]
    public string SourceName { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("sourceSubpath")]
    public string? SourceSubpath { get; set; }

    [JsonPropertyName("targetName")]
    [Required]
    public string TargetName { get; set; }

    [JsonPropertyName("targetResourceId")]
    public string? TargetResourceId { get; set; }

    [JsonPropertyName("targetSubpath")]
    public string? TargetSubpath { get; set; }
}
