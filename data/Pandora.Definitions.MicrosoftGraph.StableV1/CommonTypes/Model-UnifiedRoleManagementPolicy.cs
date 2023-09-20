// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UnifiedRoleManagementPolicyModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("effectiveRules")]
    public List<UnifiedRoleManagementPolicyRuleModel>? EffectiveRules { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isOrganizationDefault")]
    public bool? IsOrganizationDefault { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentityModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rules")]
    public List<UnifiedRoleManagementPolicyRuleModel>? Rules { get; set; }

    [JsonPropertyName("scopeId")]
    public string? ScopeId { get; set; }

    [JsonPropertyName("scopeType")]
    public string? ScopeType { get; set; }
}
