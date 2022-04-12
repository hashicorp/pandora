using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class AllowedAudiencesValidationModel
{
    [JsonPropertyName("allowedAudiences")]
    public List<string>? AllowedAudiences { get; set; }
}
