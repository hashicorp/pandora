// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EducationSubmissionModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("outcomes")]
    public List<EducationOutcomeModel>? Outcomes { get; set; }

    [JsonPropertyName("reassignedBy")]
    public IdentitySetModel? ReassignedBy { get; set; }

    [JsonPropertyName("reassignedDateTime")]
    public DateTime? ReassignedDateTime { get; set; }

    [JsonPropertyName("recipient")]
    public EducationSubmissionRecipientModel? Recipient { get; set; }

    [JsonPropertyName("resources")]
    public List<EducationSubmissionResourceModel>? Resources { get; set; }

    [JsonPropertyName("resourcesFolderUrl")]
    public string? ResourcesFolderUrl { get; set; }

    [JsonPropertyName("returnedBy")]
    public IdentitySetModel? ReturnedBy { get; set; }

    [JsonPropertyName("returnedDateTime")]
    public DateTime? ReturnedDateTime { get; set; }

    [JsonPropertyName("status")]
    public EducationSubmissionStatusConstant? Status { get; set; }

    [JsonPropertyName("submittedBy")]
    public IdentitySetModel? SubmittedBy { get; set; }

    [JsonPropertyName("submittedDateTime")]
    public DateTime? SubmittedDateTime { get; set; }

    [JsonPropertyName("submittedResources")]
    public List<EducationSubmissionResourceModel>? SubmittedResources { get; set; }

    [JsonPropertyName("unsubmittedBy")]
    public IdentitySetModel? UnsubmittedBy { get; set; }

    [JsonPropertyName("unsubmittedDateTime")]
    public DateTime? UnsubmittedDateTime { get; set; }
}
