// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationSynchronizationProfileStatusModel
{
    [JsonPropertyName("errorCount")]
    public int? ErrorCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastActivityDateTime")]
    public DateTime? LastActivityDateTime { get; set; }

    [JsonPropertyName("lastSynchronizationDateTime")]
    public DateTime? LastSynchronizationDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public EducationSynchronizationProfileStatusStatusConstant? Status { get; set; }

    [JsonPropertyName("statusMessage")]
    public string? StatusMessage { get; set; }
}
