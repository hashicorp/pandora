using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class GlobalValidationModel
{
    [JsonPropertyName("excludedPaths")]
    public List<string>? ExcludedPaths { get; set; }

    [JsonPropertyName("redirectToProvider")]
    public string? RedirectToProvider { get; set; }

    [JsonPropertyName("unauthenticatedClientAction")]
    public UnauthenticatedClientActionV2Constant? UnauthenticatedClientAction { get; set; }
}
