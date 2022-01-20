using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LoadTestService.v2021_12_01_preview.LoadTests;


internal class LoadTestResourcePatchRequestBodyModel
{
    [JsonPropertyName("identity")]
    public CustomTypes.SystemAssignedIdentity? Identity { get; set; }

    [JsonPropertyName("properties")]
    public LoadTestResourcePatchRequestBodyPropertiesModel? Properties { get; set; }

    [JsonPropertyName("tags")]
    public object? Tags { get; set; }
}
