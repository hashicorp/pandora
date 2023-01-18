using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleManagementPolicyAssignments;


internal abstract class RoleManagementPolicyRuleModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ruleType")]
    [ProvidesTypeHint]
    [Required]
    public RoleManagementPolicyRuleTypeConstant RuleType { get; set; }

    [JsonPropertyName("target")]
    public RoleManagementPolicyRuleTargetModel? Target { get; set; }
}
