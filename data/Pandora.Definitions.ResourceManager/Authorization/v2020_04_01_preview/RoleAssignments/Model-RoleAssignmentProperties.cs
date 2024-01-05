using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_04_01_preview.RoleAssignments;


internal class RoleAssignmentPropertiesModel
{
    [JsonPropertyName("canDelegate")]
    public bool? CanDelegate { get; set; }

    [JsonPropertyName("condition")]
    public string? Condition { get; set; }

    [JsonPropertyName("conditionVersion")]
    public string? ConditionVersion { get; set; }

    [JsonPropertyName("delegatedManagedIdentityResourceId")]
    public string? DelegatedManagedIdentityResourceId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("principalId")]
    [Required]
    public string PrincipalId { get; set; }

    [JsonPropertyName("principalType")]
    public PrincipalTypeConstant? PrincipalType { get; set; }

    [JsonPropertyName("roleDefinitionId")]
    [Required]
    public string RoleDefinitionId { get; set; }
}
