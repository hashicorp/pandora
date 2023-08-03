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
    public long? FailedSignInCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("migrationStatus")]
    public MigrationStatusConstant? MigrationStatus { get; set; }

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
    public long? SuccessfulSignInCount { get; set; }

    [JsonPropertyName("totalSignInCount")]
    public long? TotalSignInCount { get; set; }

    [JsonPropertyName("uniqueUserCount")]
    public long? UniqueUserCount { get; set; }
}
