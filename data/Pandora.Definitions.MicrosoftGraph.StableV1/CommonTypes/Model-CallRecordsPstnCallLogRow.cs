// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CallRecordsPstnCallLogRowModel
{
    [JsonPropertyName("callDurationSource")]
    public CallRecordsPstnCallLogRowCallDurationSourceConstant? CallDurationSource { get; set; }

    [JsonPropertyName("callId")]
    public string? CallId { get; set; }

    [JsonPropertyName("callType")]
    public string? CallType { get; set; }

    [JsonPropertyName("calleeNumber")]
    public string? CalleeNumber { get; set; }

    [JsonPropertyName("callerNumber")]
    public string? CallerNumber { get; set; }

    [JsonPropertyName("charge")]
    public float? Charge { get; set; }

    [JsonPropertyName("conferenceId")]
    public string? ConferenceId { get; set; }

    [JsonPropertyName("connectionCharge")]
    public float? ConnectionCharge { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("destinationContext")]
    public string? DestinationContext { get; set; }

    [JsonPropertyName("destinationName")]
    public string? DestinationName { get; set; }

    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inventoryType")]
    public string? InventoryType { get; set; }

    [JsonPropertyName("licenseCapability")]
    public string? LicenseCapability { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operator")]
    public string? Operator { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("tenantCountryCode")]
    public string? TenantCountryCode { get; set; }

    [JsonPropertyName("usageCountryCode")]
    public string? UsageCountryCode { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
