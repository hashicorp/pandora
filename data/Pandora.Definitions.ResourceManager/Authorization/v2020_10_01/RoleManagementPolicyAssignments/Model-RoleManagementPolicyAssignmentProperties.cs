using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleManagementPolicyAssignments;


internal class RoleManagementPolicyAssignmentPropertiesModel
{
    [JsonPropertyName("effectiveRules")]
    public List<RoleManagementPolicyRuleModel>? EffectiveRules { get; set; }

    [JsonPropertyName("policyAssignmentProperties")]
    public PolicyAssignmentPropertiesModel? PolicyAssignmentProperties { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    public string? RoleDefinitionId { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }
}
