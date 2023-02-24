using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.PipelineRuns;


internal class PipelineRunInvokedByModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("invokedByType")]
    public string? InvokedByType { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("pipelineName")]
    public string? PipelineName { get; set; }

    [JsonPropertyName("pipelineRunId")]
    public string? PipelineRunId { get; set; }
}
