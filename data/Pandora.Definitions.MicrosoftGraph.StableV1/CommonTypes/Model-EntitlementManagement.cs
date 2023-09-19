// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EntitlementManagementModel
{
    [JsonPropertyName("accessPackageAssignmentApprovals")]
    public List<ApprovalModel>? AccessPackageAssignmentApprovals { get; set; }

    [JsonPropertyName("accessPackages")]
    public List<AccessPackageModel>? AccessPackages { get; set; }

    [JsonPropertyName("assignmentPolicies")]
    public List<AccessPackageAssignmentPolicyModel>? AssignmentPolicies { get; set; }

    [JsonPropertyName("assignmentRequests")]
    public List<AccessPackageAssignmentRequestModel>? AssignmentRequests { get; set; }

    [JsonPropertyName("assignments")]
    public List<AccessPackageAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("catalogs")]
    public List<AccessPackageCatalogModel>? Catalogs { get; set; }

    [JsonPropertyName("connectedOrganizations")]
    public List<ConnectedOrganizationModel>? ConnectedOrganizations { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceEnvironments")]
    public List<AccessPackageResourceEnvironmentModel>? ResourceEnvironments { get; set; }

    [JsonPropertyName("resourceRequests")]
    public List<AccessPackageResourceRequestModel>? ResourceRequests { get; set; }

    [JsonPropertyName("resourceRoleScopes")]
    public List<AccessPackageResourceRoleScopeModel>? ResourceRoleScopes { get; set; }

    [JsonPropertyName("resources")]
    public List<AccessPackageResourceModel>? Resources { get; set; }

    [JsonPropertyName("settings")]
    public EntitlementManagementSettingsModel? Settings { get; set; }
}
