using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.PipelineRuns;


internal class PipelineRunResponseModel
{
    [JsonPropertyName("catalogDigest")]
    public string? CatalogDigest { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("finishTime")]
    public DateTime? FinishTime { get; set; }

    [JsonPropertyName("importedArtifacts")]
    public List<string>? ImportedArtifacts { get; set; }

    [JsonPropertyName("pipelineRunErrorMessage")]
    public string? PipelineRunErrorMessage { get; set; }

    [JsonPropertyName("progress")]
    public ProgressPropertiesModel? Progress { get; set; }

    [JsonPropertyName("source")]
    public ImportPipelineSourcePropertiesModel? Source { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("target")]
    public ExportPipelineTargetPropertiesModel? Target { get; set; }

    [JsonPropertyName("trigger")]
    public PipelineTriggerDescriptorModel? Trigger { get; set; }
}
