// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ItemRetentionLabelModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isLabelAppliedExplicitly")]
    public bool? IsLabelAppliedExplicitly { get; set; }

    [JsonPropertyName("labelAppliedBy")]
    public IdentitySetModel? LabelAppliedBy { get; set; }

    [JsonPropertyName("labelAppliedDateTime")]
    public DateTime? LabelAppliedDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("retentionSettings")]
    public RetentionLabelSettingsModel? RetentionSettings { get; set; }
}
