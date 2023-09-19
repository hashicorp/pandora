// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UpdateAllowedCombinationsResultModel
{
    [JsonPropertyName("additionalInformation")]
    public string? AdditionalInformation { get; set; }

    [JsonPropertyName("conditionalAccessReferences")]
    public List<string>? ConditionalAccessReferences { get; set; }

    [JsonPropertyName("currentCombinations")]
    public List<UpdateAllowedCombinationsResultCurrentCombinationsConstant>? CurrentCombinations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("previousCombinations")]
    public List<UpdateAllowedCombinationsResultPreviousCombinationsConstant>? PreviousCombinations { get; set; }
}
