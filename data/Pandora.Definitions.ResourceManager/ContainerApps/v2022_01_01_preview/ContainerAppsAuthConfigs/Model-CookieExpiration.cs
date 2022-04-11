using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class CookieExpirationModel
{
    [JsonPropertyName("convention")]
    public CookieExpirationConventionConstant? Convention { get; set; }

    [JsonPropertyName("timeToExpiration")]
    public string? TimeToExpiration { get; set; }
}
