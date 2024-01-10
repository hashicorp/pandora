// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessReviewHistoryInstanceModel
{
    [JsonPropertyName("downloadUri")]
    public string? DownloadUri { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("fulfilledDateTime")]
    public DateTime? FulfilledDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reviewHistoryPeriodEndDateTime")]
    public DateTime? ReviewHistoryPeriodEndDateTime { get; set; }

    [JsonPropertyName("reviewHistoryPeriodStartDateTime")]
    public DateTime? ReviewHistoryPeriodStartDateTime { get; set; }

    [JsonPropertyName("runDateTime")]
    public DateTime? RunDateTime { get; set; }

    [JsonPropertyName("status")]
    public AccessReviewHistoryInstanceStatusConstant? Status { get; set; }
}
