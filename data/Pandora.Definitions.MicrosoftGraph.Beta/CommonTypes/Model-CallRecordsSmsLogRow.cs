// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallRecordsSmsLogRowModel
{
    [JsonPropertyName("callCharge")]
    public float? CallCharge { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("destinationContext")]
    public string? DestinationContext { get; set; }

    [JsonPropertyName("destinationName")]
    public string? DestinationName { get; set; }

    [JsonPropertyName("destinationNumber")]
    public string? DestinationNumber { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("licenseCapability")]
    public string? LicenseCapability { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("otherPartyCountryCode")]
    public string? OtherPartyCountryCode { get; set; }

    [JsonPropertyName("sentDateTime")]
    public DateTime? SentDateTime { get; set; }

    [JsonPropertyName("smsId")]
    public string? SmsId { get; set; }

    [JsonPropertyName("smsType")]
    public string? SmsType { get; set; }

    [JsonPropertyName("smsUnits")]
    public int? SmsUnits { get; set; }

    [JsonPropertyName("sourceNumber")]
    public string? SourceNumber { get; set; }

    [JsonPropertyName("tenantCountryCode")]
    public string? TenantCountryCode { get; set; }

    [JsonPropertyName("userCountryCode")]
    public string? UserCountryCode { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
