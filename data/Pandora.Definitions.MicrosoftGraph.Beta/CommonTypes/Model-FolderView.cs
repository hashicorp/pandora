// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class FolderViewModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sortBy")]
    public string? SortBy { get; set; }

    [JsonPropertyName("sortOrder")]
    public string? SortOrder { get; set; }

    [JsonPropertyName("viewType")]
    public string? ViewType { get; set; }
}
