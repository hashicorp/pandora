// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EmbeddedSIMActivationCodeModel
{
    [JsonPropertyName("integratedCircuitCardIdentifier")]
    public string? IntegratedCircuitCardIdentifier { get; set; }

    [JsonPropertyName("matchingIdentifier")]
    public string? MatchingIdentifier { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("smdpPlusServerAddress")]
    public string? SmdpPlusServerAddress { get; set; }
}
