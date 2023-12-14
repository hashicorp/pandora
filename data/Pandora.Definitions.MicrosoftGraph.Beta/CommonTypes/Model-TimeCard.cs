// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TimeCardModel
{
    [JsonPropertyName("breaks")]
    public List<TimeCardBreakModel>? Breaks { get; set; }

    [JsonPropertyName("clockInEvent")]
    public TimeCardEventModel? ClockInEvent { get; set; }

    [JsonPropertyName("clockOutEvent")]
    public TimeCardEventModel? ClockOutEvent { get; set; }

    [JsonPropertyName("confirmedBy")]
    public TimeCardConfirmedByConstant? ConfirmedBy { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("notes")]
    public ItemBodyModel? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("originalEntry")]
    public TimeCardEntryModel? OriginalEntry { get; set; }

    [JsonPropertyName("state")]
    public TimeCardStateConstant? State { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}
