// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallRecordsDirectRoutingLogRowModel
{
    [JsonPropertyName("callEndSubReason")]
    public int? CallEndSubReason { get; set; }

    [JsonPropertyName("callType")]
    public string? CallType { get; set; }

    [JsonPropertyName("calleeNumber")]
    public string? CalleeNumber { get; set; }

    [JsonPropertyName("callerNumber")]
    public string? CallerNumber { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("failureDateTime")]
    public DateTime? FailureDateTime { get; set; }

    [JsonPropertyName("finalSipCode")]
    public int? FinalSipCode { get; set; }

    [JsonPropertyName("finalSipCodePhrase")]
    public string? FinalSipCodePhrase { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("inviteDateTime")]
    public DateTime? InviteDateTime { get; set; }

    [JsonPropertyName("mediaBypassEnabled")]
    public bool? MediaBypassEnabled { get; set; }

    [JsonPropertyName("mediaPathLocation")]
    public string? MediaPathLocation { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("otherPartyCountryCode")]
    public string? OtherPartyCountryCode { get; set; }

    [JsonPropertyName("signalingLocation")]
    public string? SignalingLocation { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("successfulCall")]
    public bool? SuccessfulCall { get; set; }

    [JsonPropertyName("trunkFullyQualifiedDomainName")]
    public string? TrunkFullyQualifiedDomainName { get; set; }

    [JsonPropertyName("userCountryCode")]
    public string? UserCountryCode { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
