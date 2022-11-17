using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ValueForType("AutoML")]
internal class AutoMLJobModel : JobBaseModel
{
    [JsonPropertyName("environmentId")]
    public string? EnvironmentId { get; set; }

    [JsonPropertyName("environmentVariables")]
    public Dictionary<string, string>? EnvironmentVariables { get; set; }

    [JsonPropertyName("outputs")]
    public Dictionary<string, JobOutputModel>? Outputs { get; set; }

    [JsonPropertyName("resources")]
    public JobResourceConfigurationModel? Resources { get; set; }

    [JsonPropertyName("taskDetails")]
    [Required]
    public AutoMLVerticalModel TaskDetails { get; set; }
}
