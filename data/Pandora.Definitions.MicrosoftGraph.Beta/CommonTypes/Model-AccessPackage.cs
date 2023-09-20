// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageModel
{
    [JsonPropertyName("accessPackageAssignmentPolicies")]
    public List<AccessPackageAssignmentPolicyModel>? AccessPackageAssignmentPolicies { get; set; }

    [JsonPropertyName("accessPackageCatalog")]
    public AccessPackageCatalogModel? AccessPackageCatalog { get; set; }

    [JsonPropertyName("accessPackageResourceRoleScopes")]
    public List<AccessPackageResourceRoleScopeModel>? AccessPackageResourceRoleScopes { get; set; }

    [JsonPropertyName("accessPackagesIncompatibleWith")]
    public List<AccessPackageModel>? AccessPackagesIncompatibleWith { get; set; }

    [JsonPropertyName("catalogId")]
    public string? CatalogId { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

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

    [JsonPropertyName("isRoleScopesVisible")]
    public bool? IsRoleScopesVisible { get; set; }

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
