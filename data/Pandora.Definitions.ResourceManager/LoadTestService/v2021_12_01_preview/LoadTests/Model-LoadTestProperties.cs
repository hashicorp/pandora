using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LoadTestService.v2021_12_01_preview.LoadTests;


internal class LoadTestPropertiesModel
{
    [JsonPropertyName("dataPlaneURI")]
    public string? DataPlaneURI { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("provisioningState")]
    public ResourceStateConstant? ProvisioningState { get; set; }
}
