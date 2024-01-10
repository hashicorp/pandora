// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SignInModel
{
    [JsonPropertyName("appDisplayName")]
    public string? AppDisplayName { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appliedConditionalAccessPolicies")]
    public List<AppliedConditionalAccessPolicyModel>? AppliedConditionalAccessPolicies { get; set; }

    [JsonPropertyName("clientAppUsed")]
    public string? ClientAppUsed { get; set; }

    [JsonPropertyName("conditionalAccessStatus")]
    public SignInConditionalAccessStatusConstant? ConditionalAccessStatus { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deviceDetail")]
    public DeviceDetailModel? DeviceDetail { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("isInteractive")]
    public bool? IsInteractive { get; set; }

    [JsonPropertyName("location")]
    public SignInLocationModel? Location { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceDisplayName")]
    public string? ResourceDisplayName { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("riskDetail")]
    public SignInRiskDetailConstant? RiskDetail { get; set; }

    [JsonPropertyName("riskEventTypes")]
    public List<SignInRiskEventTypesConstant>? RiskEventTypes { get; set; }

    [JsonPropertyName("riskEventTypes_v2")]
    public List<string>? RiskEventTypesv2 { get; set; }

    [JsonPropertyName("riskLevelAggregated")]
    public SignInRiskLevelAggregatedConstant? RiskLevelAggregated { get; set; }

    [JsonPropertyName("riskLevelDuringSignIn")]
    public SignInRiskLevelDuringSignInConstant? RiskLevelDuringSignIn { get; set; }

    [JsonPropertyName("riskState")]
    public SignInRiskStateConstant? RiskState { get; set; }

    [JsonPropertyName("status")]
    public SignInStatusModel? Status { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
