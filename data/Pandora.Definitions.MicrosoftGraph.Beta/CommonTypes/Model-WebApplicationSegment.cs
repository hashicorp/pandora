// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WebApplicationSegmentModel
{
    [JsonPropertyName("alternateUrl")]
    public string? AlternateUrl { get; set; }

    [JsonPropertyName("corsConfigurations")]
    public List<CorsConfigurationv2Model>? CorsConfigurations { get; set; }

    [JsonPropertyName("externalUrl")]
    public string? ExternalUrl { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("internalUrl")]
    public string? InternalUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
