// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageAssignmentModel
{
    [JsonPropertyName("accessPackage")]
    public AccessPackageModel? AccessPackage { get; set; }

    [JsonPropertyName("accessPackageAssignmentPolicy")]
    public AccessPackageAssignmentPolicyModel? AccessPackageAssignmentPolicy { get; set; }

    [JsonPropertyName("accessPackageAssignmentRequests")]
    public List<AccessPackageAssignmentRequestModel>? AccessPackageAssignmentRequests { get; set; }

    [JsonPropertyName("accessPackageAssignmentResourceRoles")]
    public List<AccessPackageAssignmentResourceRoleModel>? AccessPackageAssignmentResourceRoles { get; set; }

    [JsonPropertyName("accessPackageId")]
    public string? AccessPackageId { get; set; }

    [JsonPropertyName("assignmentPolicyId")]
    public string? AssignmentPolicyId { get; set; }

    [JsonPropertyName("assignmentState")]
    public string? AssignmentState { get; set; }

    [JsonPropertyName("assignmentStatus")]
    public string? AssignmentStatus { get; set; }

    [JsonPropertyName("catalogId")]
    public string? CatalogId { get; set; }

    [JsonPropertyName("customExtensionCalloutInstances")]
    public List<CustomExtensionCalloutInstanceModel>? CustomExtensionCalloutInstances { get; set; }

    [JsonPropertyName("expiredDateTime")]
    public DateTime? ExpiredDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isExtended")]
    public bool? IsExtended { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schedule")]
    public RequestScheduleModel? Schedule { get; set; }

    [JsonPropertyName("target")]
    public AccessPackageSubjectModel? Target { get; set; }

    [JsonPropertyName("targetId")]
    public string? TargetId { get; set; }
}
