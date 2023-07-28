using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ValueForType("Spark")]
internal class SparkJobModel : JobBaseModel
{
    [JsonPropertyName("archives")]
    public List<string>? Archives { get; set; }

    [JsonPropertyName("args")]
    public string? Args { get; set; }

    [JsonPropertyName("codeId")]
    [Required]
    public string CodeId { get; set; }

    [JsonPropertyName("conf")]
    public Dictionary<string, string>? Conf { get; set; }

    [JsonPropertyName("entry")]
    [Required]
    public SparkJobEntryModel Entry { get; set; }

    [JsonPropertyName("environmentId")]
    public string? EnvironmentId { get; set; }

    [JsonPropertyName("files")]
    public List<string>? Files { get; set; }

    [JsonPropertyName("inputs")]
    public Dictionary<string, JobInputModel>? Inputs { get; set; }

    [JsonPropertyName("jars")]
    public List<string>? Jars { get; set; }

    [JsonPropertyName("outputs")]
    public Dictionary<string, JobOutputModel>? Outputs { get; set; }

    [JsonPropertyName("pyFiles")]
    public List<string>? PyFiles { get; set; }

    [JsonPropertyName("queueSettings")]
    public QueueSettingsModel? QueueSettings { get; set; }

    [JsonPropertyName("resources")]
    public SparkResourceConfigurationModel? Resources { get; set; }
}
