using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2021_09_15_preview.Experiments;


internal class ExperimentExecutionDetailsPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDateUtc")]
    public DateTime? CreatedDateUtc { get; set; }

    [JsonPropertyName("experimentId")]
    public string? ExperimentId { get; set; }

    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastActionDateUtc")]
    public DateTime? LastActionDateUtc { get; set; }

    [JsonPropertyName("runInformation")]
    public ExperimentExecutionDetailsPropertiesRunInformationModel? RunInformation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDateUtc")]
    public DateTime? StartDateUtc { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("stopDateUtc")]
    public DateTime? StopDateUtc { get; set; }
}
