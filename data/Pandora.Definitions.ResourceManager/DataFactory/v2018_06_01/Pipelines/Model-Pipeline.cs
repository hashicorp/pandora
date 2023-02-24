using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Pipelines;


internal class PipelineModel
{
    [JsonPropertyName("activities")]
    public List<ActivityModel>? Activities { get; set; }

    [JsonPropertyName("annotations")]
    public List<object>? Annotations { get; set; }

    [JsonPropertyName("concurrency")]
    public int? Concurrency { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("folder")]
    public PipelineFolderModel? Folder { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, ParameterSpecificationModel>? Parameters { get; set; }

    [JsonPropertyName("policy")]
    public PipelinePolicyModel? Policy { get; set; }

    [JsonPropertyName("runDimensions")]
    public Dictionary<string, object>? RunDimensions { get; set; }

    [JsonPropertyName("variables")]
    public Dictionary<string, VariableSpecificationModel>? Variables { get; set; }
}
