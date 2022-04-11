using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class CustomOpenIdConnectProviderModel
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("login")]
    public OpenIdConnectLoginModel? Login { get; set; }

    [JsonPropertyName("registration")]
    public OpenIdConnectRegistrationModel? Registration { get; set; }
}
