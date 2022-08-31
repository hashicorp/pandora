using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Job;

[ValueForType("Command")]
internal class CommandJobModel : JobBaseModel
{
    [JsonPropertyName("codeId")]
    public string? CodeId { get; set; }

    [JsonPropertyName("command")]
    [Required]
    public string Command { get; set; }

    [JsonPropertyName("distribution")]
    public DistributionConfigurationModel? Distribution { get; set; }

    [JsonPropertyName("environmentId")]
    [Required]
    public string EnvironmentId { get; set; }

    [JsonPropertyName("environmentVariables")]
    public Dictionary<string, string>? EnvironmentVariables { get; set; }

    [JsonPropertyName("inputs")]
    public Dictionary<string, JobInputModel>? Inputs { get; set; }

    [JsonPropertyName("limits")]
    public JobLimitsModel? Limits { get; set; }

    [JsonPropertyName("outputs")]
    public Dictionary<string, JobOutputModel>? Outputs { get; set; }

    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }

    [JsonPropertyName("resources")]
    public ResourceConfigurationModel? Resources { get; set; }
}
