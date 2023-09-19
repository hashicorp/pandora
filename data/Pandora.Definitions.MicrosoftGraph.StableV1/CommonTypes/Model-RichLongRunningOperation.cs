// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class RichLongRunningOperationModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("error")]
    public PublicErrorModel? Error { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastActionDateTime")]
    public DateTime? LastActionDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("percentageComplete")]
    public int? PercentageComplete { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("resourceLocation")]
    public string? ResourceLocation { get; set; }

    [JsonPropertyName("status")]
    public RichLongRunningOperationStatusConstant? Status { get; set; }

    [JsonPropertyName("statusDetail")]
    public string? StatusDetail { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
