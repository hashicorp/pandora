// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageAssignmentPolicyModel
{
    [JsonPropertyName("accessPackage")]
    public AccessPackageModel? AccessPackage { get; set; }

    [JsonPropertyName("accessPackageCatalog")]
    public AccessPackageCatalogModel? AccessPackageCatalog { get; set; }

    [JsonPropertyName("accessPackageId")]
    public string? AccessPackageId { get; set; }

    [JsonPropertyName("accessReviewSettings")]
    public AssignmentReviewSettingsModel? AccessReviewSettings { get; set; }

    [JsonPropertyName("canExtend")]
    public bool? CanExtend { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customExtensionHandlers")]
    public List<CustomExtensionHandlerModel>? CustomExtensionHandlers { get; set; }

    [JsonPropertyName("customExtensionStageSettings")]
    public List<CustomExtensionStageSettingModel>? CustomExtensionStageSettings { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("durationInDays")]
    public int? DurationInDays { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("questions")]
    public List<AccessPackageQuestionModel>? Questions { get; set; }

    [JsonPropertyName("requestApprovalSettings")]
    public ApprovalSettingsModel? RequestApprovalSettings { get; set; }

    [JsonPropertyName("requestorSettings")]
    public RequestorSettingsModel? RequestorSettings { get; set; }

    [JsonPropertyName("verifiableCredentialSettings")]
    public VerifiableCredentialSettingsModel? VerifiableCredentialSettings { get; set; }
}
