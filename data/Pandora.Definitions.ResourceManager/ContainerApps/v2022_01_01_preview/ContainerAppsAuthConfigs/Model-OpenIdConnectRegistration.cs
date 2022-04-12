using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class OpenIdConnectRegistrationModel
{
    [JsonPropertyName("clientCredential")]
    public OpenIdConnectClientCredentialModel? ClientCredential { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("openIdConnectConfiguration")]
    public OpenIdConnectConfigModel? OpenIdConnectConfiguration { get; set; }
}
