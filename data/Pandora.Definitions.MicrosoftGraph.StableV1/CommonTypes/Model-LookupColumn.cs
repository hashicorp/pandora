// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class LookupColumnModel
{
    [JsonPropertyName("allowMultipleValues")]
    public bool? AllowMultipleValues { get; set; }

    [JsonPropertyName("allowUnlimitedLength")]
    public bool? AllowUnlimitedLength { get; set; }

    [JsonPropertyName("columnName")]
    public string? ColumnName { get; set; }

    [JsonPropertyName("listId")]
    public string? ListId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("primaryLookupColumnId")]
    public string? PrimaryLookupColumnId { get; set; }
}
