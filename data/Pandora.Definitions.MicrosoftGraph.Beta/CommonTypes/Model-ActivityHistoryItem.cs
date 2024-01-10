// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ActivityHistoryItemModel
{
    [JsonPropertyName("activeDurationSeconds")]
    public int? ActiveDurationSeconds { get; set; }

    [JsonPropertyName("activity")]
    public UserActivityModel? Activity { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastActiveDateTime")]
    public DateTime? LastActiveDateTime { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startedDateTime")]
    public DateTime? StartedDateTime { get; set; }

    [JsonPropertyName("status")]
    public ActivityHistoryItemStatusConstant? Status { get; set; }

    [JsonPropertyName("userTimezone")]
    public string? UserTimezone { get; set; }
}
