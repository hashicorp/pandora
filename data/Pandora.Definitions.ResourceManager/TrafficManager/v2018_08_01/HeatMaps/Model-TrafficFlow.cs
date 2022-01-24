using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.HeatMaps;


internal class TrafficFlowModel
{
    [JsonPropertyName("latitude")]
    public float? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public float? Longitude { get; set; }

    [JsonPropertyName("queryExperiences")]
    public List<QueryExperienceModel>? QueryExperiences { get; set; }

    [JsonPropertyName("sourceIp")]
    public string? SourceIp { get; set; }
}
