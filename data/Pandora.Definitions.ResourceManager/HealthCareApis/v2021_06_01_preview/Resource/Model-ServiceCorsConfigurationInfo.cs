using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.Resource;


internal class ServiceCorsConfigurationInfoModel
{
    [JsonPropertyName("allowCredentials")]
    public bool? AllowCredentials { get; set; }

    [JsonPropertyName("headers")]
    public List<string>? Headers { get; set; }

    [JsonPropertyName("maxAge")]
    public int? MaxAge { get; set; }

    [JsonPropertyName("methods")]
    public List<string>? Methods { get; set; }

    [JsonPropertyName("origins")]
    public List<string>? Origins { get; set; }
}
