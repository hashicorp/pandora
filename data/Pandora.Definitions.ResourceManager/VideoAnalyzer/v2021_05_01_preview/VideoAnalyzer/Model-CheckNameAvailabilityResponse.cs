using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;


internal class CheckNameAvailabilityResponseModel
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("nameAvailable")]
    public bool? NameAvailable { get; set; }

    [JsonPropertyName("reason")]
    public CheckNameAvailabilityReasonConstant? Reason { get; set; }
}
