// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageAssignmentRequestRequirementsModel
{
    [JsonPropertyName("existingAnswers")]
    public List<AccessPackageAnswerModel>? ExistingAnswers { get; set; }

    [JsonPropertyName("isApprovalRequired")]
    public bool? IsApprovalRequired { get; set; }

    [JsonPropertyName("isApprovalRequiredForExtension")]
    public bool? IsApprovalRequiredForExtension { get; set; }

    [JsonPropertyName("isCustomAssignmentScheduleAllowed")]
    public bool? IsCustomAssignmentScheduleAllowed { get; set; }

    [JsonPropertyName("isRequestorJustificationRequired")]
    public bool? IsRequestorJustificationRequired { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyDescription")]
    public string? PolicyDescription { get; set; }

    [JsonPropertyName("policyDisplayName")]
    public string? PolicyDisplayName { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("questions")]
    public List<AccessPackageQuestionModel>? Questions { get; set; }

    [JsonPropertyName("schedule")]
    public RequestScheduleModel? Schedule { get; set; }

    [JsonPropertyName("verifiableCredentialRequirementStatus")]
    public VerifiableCredentialRequirementStatusModel? VerifiableCredentialRequirementStatus { get; set; }
}
