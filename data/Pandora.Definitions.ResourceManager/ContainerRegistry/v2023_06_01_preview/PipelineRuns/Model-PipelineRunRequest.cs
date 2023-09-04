using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.PipelineRuns;


internal class PipelineRunRequestModel
{
    [JsonPropertyName("artifacts")]
    public List<string>? Artifacts { get; set; }

    [JsonPropertyName("catalogDigest")]
    public string? CatalogDigest { get; set; }

    [JsonPropertyName("pipelineResourceId")]
    public string? PipelineResourceId { get; set; }

    [JsonPropertyName("source")]
    public PipelineRunSourcePropertiesModel? Source { get; set; }

    [JsonPropertyName("target")]
    public PipelineRunTargetPropertiesModel? Target { get; set; }
}
