using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleManagementPolicies;


internal class RoleManagementPolicyPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("effectiveRules")]
    public List<RoleManagementPolicyRuleModel>? EffectiveRules { get; set; }

    [JsonPropertyName("isOrganizationDefault")]
    public bool? IsOrganizationDefault { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public PrincipalModel? LastModifiedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("policyProperties")]
    public PolicyPropertiesModel? PolicyProperties { get; set; }

    [JsonPropertyName("rules")]
    public List<RoleManagementPolicyRuleModel>? Rules { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}
