using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class FacebookModel
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("graphApiVersion")]
    public string? GraphApiVersion { get; set; }

    [JsonPropertyName("login")]
    public LoginScopesModel? Login { get; set; }

    [JsonPropertyName("registration")]
    public AppRegistrationModel? Registration { get; set; }
}
