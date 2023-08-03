// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedTenantsCredentialUserRegistrationsSummaryModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastRefreshedDateTime")]
    public DateTime? LastRefreshedDateTime { get; set; }

    [JsonPropertyName("mfaAndSsprCapableUserCount")]
    public int? MfaAndSsprCapableUserCount { get; set; }

    [JsonPropertyName("mfaConditionalAccessPolicyState")]
    public string? MfaConditionalAccessPolicyState { get; set; }

    [JsonPropertyName("mfaExcludedUserCount")]
    public int? MfaExcludedUserCount { get; set; }

    [JsonPropertyName("mfaRegisteredUserCount")]
    public int? MfaRegisteredUserCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("securityDefaultsEnabled")]
    public bool? SecurityDefaultsEnabled { get; set; }

    [JsonPropertyName("ssprEnabledUserCount")]
    public int? SsprEnabledUserCount { get; set; }

    [JsonPropertyName("ssprRegisteredUserCount")]
    public int? SsprRegisteredUserCount { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("totalUserCount")]
    public int? TotalUserCount { get; set; }
}
