// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserActivityModel
{
    [JsonPropertyName("activationUrl")]
    public string? ActivationUrl { get; set; }

    [JsonPropertyName("activitySourceHost")]
    public string? ActivitySourceHost { get; set; }

    [JsonPropertyName("appActivityId")]
    public string? AppActivityId { get; set; }

    [JsonPropertyName("appDisplayName")]
    public string? AppDisplayName { get; set; }

    [JsonPropertyName("contentInfo")]
    public JsonModel? ContentInfo { get; set; }

    [JsonPropertyName("contentUrl")]
    public string? ContentUrl { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("fallbackUrl")]
    public string? FallbackUrl { get; set; }

    [JsonPropertyName("historyItems")]
    public List<ActivityHistoryItemModel>? HistoryItems { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }

    [JsonPropertyName("userTimezone")]
    public string? UserTimezone { get; set; }

    [JsonPropertyName("visualElements")]
    public VisualInfoModel? VisualElements { get; set; }
}
