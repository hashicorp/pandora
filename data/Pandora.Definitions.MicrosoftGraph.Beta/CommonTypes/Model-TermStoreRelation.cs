// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TermStoreRelationModel
{
    [JsonPropertyName("fromTerm")]
    public TermStoreTermModel? FromTerm { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("relationship")]
    public TermStoreRelationRelationshipConstant? Relationship { get; set; }

    [JsonPropertyName("set")]
    public TermStoreSetModel? Set { get; set; }

    [JsonPropertyName("toTerm")]
    public TermStoreTermModel? ToTerm { get; set; }
}
