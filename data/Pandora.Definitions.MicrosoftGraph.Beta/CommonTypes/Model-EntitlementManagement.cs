// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EntitlementManagementModel
{
    [JsonPropertyName("accessPackageAssignmentApprovals")]
    public List<ApprovalModel>? AccessPackageAssignmentApprovals { get; set; }

    [JsonPropertyName("accessPackageAssignmentPolicies")]
    public List<AccessPackageAssignmentPolicyModel>? AccessPackageAssignmentPolicies { get; set; }

    [JsonPropertyName("accessPackageAssignmentRequests")]
    public List<AccessPackageAssignmentRequestModel>? AccessPackageAssignmentRequests { get; set; }

    [JsonPropertyName("accessPackageAssignmentResourceRoles")]
    public List<AccessPackageAssignmentResourceRoleModel>? AccessPackageAssignmentResourceRoles { get; set; }

    [JsonPropertyName("accessPackageAssignments")]
    public List<AccessPackageAssignmentModel>? AccessPackageAssignments { get; set; }

    [JsonPropertyName("accessPackageCatalogs")]
    public List<AccessPackageCatalogModel>? AccessPackageCatalogs { get; set; }

    [JsonPropertyName("accessPackageResourceEnvironments")]
    public List<AccessPackageResourceEnvironmentModel>? AccessPackageResourceEnvironments { get; set; }

    [JsonPropertyName("accessPackageResourceRequests")]
    public List<AccessPackageResourceRequestModel>? AccessPackageResourceRequests { get; set; }

    [JsonPropertyName("accessPackageResourceRoleScopes")]
    public List<AccessPackageResourceRoleScopeModel>? AccessPackageResourceRoleScopes { get; set; }

    [JsonPropertyName("accessPackageResources")]
    public List<AccessPackageResourceModel>? AccessPackageResources { get; set; }

    [JsonPropertyName("accessPackages")]
    public List<AccessPackageModel>? AccessPackages { get; set; }

    [JsonPropertyName("connectedOrganizations")]
    public List<ConnectedOrganizationModel>? ConnectedOrganizations { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settings")]
    public EntitlementManagementSettingsModel? Settings { get; set; }

    [JsonPropertyName("subjects")]
    public List<AccessPackageSubjectModel>? Subjects { get; set; }
}
