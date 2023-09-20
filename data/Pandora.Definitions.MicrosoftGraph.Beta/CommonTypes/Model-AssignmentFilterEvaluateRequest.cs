// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AssignmentFilterEvaluateRequestModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("orderBy")]
    public List<string>? OrderBy { get; set; }

    [JsonPropertyName("platform")]
    public AssignmentFilterEvaluateRequestPlatformConstant? Platform { get; set; }

    [JsonPropertyName("rule")]
    public string? Rule { get; set; }

    [JsonPropertyName("search")]
    public string? Search { get; set; }

    [JsonPropertyName("skip")]
    public int? Skip { get; set; }

    [JsonPropertyName("top")]
    public int? Top { get; set; }
}
