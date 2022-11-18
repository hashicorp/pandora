using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;


internal class TrialComponentModel
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

    [JsonPropertyName("resources")]
    public JobResourceConfigurationModel? Resources { get; set; }
}
