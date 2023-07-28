using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.LabelingJob;


internal abstract class JobBaseModel
{
    [JsonPropertyName("componentId")]
    public string? ComponentId { get; set; }

    [JsonPropertyName("computeId")]
    public string? ComputeId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("experimentName")]
    public string? ExperimentName { get; set; }

    [JsonPropertyName("identity")]
    public IdentityConfigurationModel? Identity { get; set; }

    [JsonPropertyName("isArchived")]
    public bool? IsArchived { get; set; }

    [JsonPropertyName("jobType")]
    [ProvidesTypeHint]
    [Required]
    public JobTypeConstant JobType { get; set; }

    [JsonPropertyName("notificationSetting")]
    public NotificationSettingModel? NotificationSetting { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("secretsConfiguration")]
    public Dictionary<string, SecretConfigurationModel>? SecretsConfiguration { get; set; }

    [JsonPropertyName("services")]
    public Dictionary<string, JobServiceModel>? Services { get; set; }

    [JsonPropertyName("status")]
    public JobStatusConstant? Status { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
