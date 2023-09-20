// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RelyingPartyDetailedSummaryModel
{
    [JsonPropertyName("failedSignInCount")]
    public int? FailedSignInCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("migrationStatus")]
    public RelyingPartyDetailedSummaryMigrationStatusConstant? MigrationStatus { get; set; }

    [JsonPropertyName("migrationValidationDetails")]
    public List<KeyValuePairModel>? MigrationValidationDetails { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("relyingPartyId")]
    public string? RelyingPartyId { get; set; }

    [JsonPropertyName("relyingPartyName")]
    public string? RelyingPartyName { get; set; }

    [JsonPropertyName("replyUrls")]
    public List<string>? ReplyUrls { get; set; }

    [JsonPropertyName("serviceId")]
    public string? ServiceId { get; set; }

    [JsonPropertyName("successfulSignInCount")]
    public int? SuccessfulSignInCount { get; set; }

    [JsonPropertyName("totalSignInCount")]
    public int? TotalSignInCount { get; set; }

    [JsonPropertyName("uniqueUserCount")]
    public int? UniqueUserCount { get; set; }
}
