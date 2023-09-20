// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SamlOrWsFedProviderCollectionResponseModel
{
    [JsonPropertyName("@odata.count")]
    public int? ODataCount { get; set; }

    [JsonPropertyName("@odata.nextLink")]
    public string? ODataNextLink { get; set; }

    [JsonPropertyName("value")]
    public List<SamlOrWsFedProviderModel>? Value { get; set; }
}
