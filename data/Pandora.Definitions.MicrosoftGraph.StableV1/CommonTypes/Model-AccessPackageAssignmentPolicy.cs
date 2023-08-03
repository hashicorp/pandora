// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageAssignmentPolicyModel
{
    [JsonPropertyName("accessPackage")]
    public AccessPackageModel? AccessPackage { get; set; }

    [JsonPropertyName("allowedTargetScope")]
    public AllowedTargetScopeConstant? AllowedTargetScope { get; set; }

    [JsonPropertyName("automaticRequestSettings")]
    public AccessPackageAutomaticRequestSettingsModel? AutomaticRequestSettings { get; set; }

    [JsonPropertyName("catalog")]
    public AccessPackageCatalogModel? Catalog { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("expiration")]
    public ExpirationPatternModel? Expiration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("questions")]
    public List<AccessPackageQuestionModel>? Questions { get; set; }

    [JsonPropertyName("requestApprovalSettings")]
    public AccessPackageAssignmentApprovalSettingsModel? RequestApprovalSettings { get; set; }

    [JsonPropertyName("requestorSettings")]
    public AccessPackageAssignmentRequestorSettingsModel? RequestorSettings { get; set; }

    [JsonPropertyName("reviewSettings")]
    public AccessPackageAssignmentReviewSettingsModel? ReviewSettings { get; set; }

    [JsonPropertyName("specificAllowedTargets")]
    public List<SubjectSetModel>? SpecificAllowedTargets { get; set; }
}
