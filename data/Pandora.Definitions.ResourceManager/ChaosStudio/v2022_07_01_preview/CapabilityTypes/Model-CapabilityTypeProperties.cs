using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview.CapabilityTypes;


internal class CapabilityTypePropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("parametersSchema")]
    public string? ParametersSchema { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("runtimeProperties")]
    public CapabilityTypePropertiesRuntimePropertiesModel? RuntimeProperties { get; set; }

    [JsonPropertyName("targetType")]
    public string? TargetType { get; set; }

    [JsonPropertyName("urn")]
    public string? Urn { get; set; }
}
