// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageModel
{
    [JsonPropertyName("accessPackagesIncompatibleWith")]
    public List<AccessPackageModel>? AccessPackagesIncompatibleWith { get; set; }

    [JsonPropertyName("assignmentPolicies")]
    public List<AccessPackageAssignmentPolicyModel>? AssignmentPolicies { get; set; }

    [JsonPropertyName("catalog")]
    public AccessPackageCatalogModel? Catalog { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incompatibleAccessPackages")]
    public List<AccessPackageModel>? IncompatibleAccessPackages { get; set; }

    [JsonPropertyName("incompatibleGroups")]
    public List<GroupModel>? IncompatibleGroups { get; set; }

    [JsonPropertyName("isHidden")]
    public bool? IsHidden { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceRoleScopes")]
    public List<AccessPackageResourceRoleScopeModel>? ResourceRoleScopes { get; set; }
}
