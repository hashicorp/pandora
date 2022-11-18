using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Job;

[ValueForType("Pipeline")]
internal class PipelineJobModel : JobBaseModel
{
    [JsonPropertyName("inputs")]
    public Dictionary<string, JobInputModel>? Inputs { get; set; }

    [JsonPropertyName("jobs")]
    public Dictionary<string, object>? Jobs { get; set; }

    [JsonPropertyName("outputs")]
    public Dictionary<string, JobOutputModel>? Outputs { get; set; }

    [JsonPropertyName("settings")]
    public object? Settings { get; set; }

    [JsonPropertyName("sourceJobId")]
    public string? SourceJobId { get; set; }
}
