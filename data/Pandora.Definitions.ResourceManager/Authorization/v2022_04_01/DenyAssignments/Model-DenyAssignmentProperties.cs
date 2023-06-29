using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.DenyAssignments;


internal class DenyAssignmentPropertiesModel
{
    [JsonPropertyName("condition")]
    public string? Condition { get; set; }

    [JsonPropertyName("conditionVersion")]
    public string? ConditionVersion { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdOn")]
    public DateTime? CreatedOn { get; set; }

    [JsonPropertyName("denyAssignmentName")]
    public string? DenyAssignmentName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("doNotApplyToChildScopes")]
    public bool? DoNotApplyToChildScopes { get; set; }

    [JsonPropertyName("excludePrincipals")]
    public List<PrincipalModel>? ExcludePrincipals { get; set; }

    [JsonPropertyName("isSystemProtected")]
    public bool? IsSystemProtected { get; set; }

    [JsonPropertyName("permissions")]
    public List<DenyAssignmentPermissionModel>? Permissions { get; set; }

    [JsonPropertyName("principals")]
    public List<PrincipalModel>? Principals { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("updatedBy")]
    public string? UpdatedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updatedOn")]
    public DateTime? UpdatedOn { get; set; }
}
