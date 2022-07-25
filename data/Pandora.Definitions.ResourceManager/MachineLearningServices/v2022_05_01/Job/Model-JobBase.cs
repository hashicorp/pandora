using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Job;


internal abstract class JobBaseModel
{
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

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("services")]
    public Dictionary<string, JobServiceModel>? Services { get; set; }

    [JsonPropertyName("status")]
    public JobStatusConstant? Status { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
