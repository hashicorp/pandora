// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CorsConfigurationModel
{
    [JsonPropertyName("allowedHeaders")]
    public List<string>? AllowedHeaders { get; set; }

    [JsonPropertyName("allowedMethods")]
    public List<string>? AllowedMethods { get; set; }

    [JsonPropertyName("allowedOrigins")]
    public List<string>? AllowedOrigins { get; set; }

    [JsonPropertyName("maxAgeInSeconds")]
    public int? MaxAgeInSeconds { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resource")]
    public string? Resource { get; set; }
}
