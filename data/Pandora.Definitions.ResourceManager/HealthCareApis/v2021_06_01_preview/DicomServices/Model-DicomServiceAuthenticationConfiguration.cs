using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.DicomServices;


internal class DicomServiceAuthenticationConfigurationModel
{
    [JsonPropertyName("audiences")]
    public List<string>? Audiences { get; set; }

    [JsonPropertyName("authority")]
    public string? Authority { get; set; }
}
