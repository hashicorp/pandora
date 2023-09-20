// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GovernanceRoleSettingModel
{
    [JsonPropertyName("adminEligibleSettings")]
    public List<GovernanceRuleSettingModel>? AdminEligibleSettings { get; set; }

    [JsonPropertyName("adminMemberSettings")]
    public List<GovernanceRuleSettingModel>? AdminMemberSettings { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("lastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resource")]
    public GovernanceResourceModel? Resource { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("roleDefinition")]
    public GovernanceRoleDefinitionModel? RoleDefinition { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    public string? RoleDefinitionId { get; set; }

    [JsonPropertyName("userEligibleSettings")]
    public List<GovernanceRuleSettingModel>? UserEligibleSettings { get; set; }

    [JsonPropertyName("userMemberSettings")]
    public List<GovernanceRuleSettingModel>? UserMemberSettings { get; set; }
}
