using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class OpenIdConnectLoginModel
{
    [JsonPropertyName("nameClaimType")]
    public string? NameClaimType { get; set; }

    [JsonPropertyName("scopes")]
    public List<string>? Scopes { get; set; }
}
