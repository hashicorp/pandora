// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SubjectRightsRequestModel
{
    [JsonPropertyName("approvers")]
    public List<UserModel>? Approvers { get; set; }

    [JsonPropertyName("assignedTo")]
    public IdentityModel? AssignedTo { get; set; }

    [JsonPropertyName("closedDateTime")]
    public DateTime? ClosedDateTime { get; set; }

    [JsonPropertyName("collaborators")]
    public List<UserModel>? Collaborators { get; set; }

    [JsonPropertyName("contentQuery")]
    public string? ContentQuery { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dataSubject")]
    public DataSubjectModel? DataSubject { get; set; }

    [JsonPropertyName("dataSubjectType")]
    public SubjectRightsRequestDataSubjectTypeConstant? DataSubjectType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("history")]
    public List<SubjectRightsRequestHistoryModel>? History { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includeAllVersions")]
    public bool? IncludeAllVersions { get; set; }

    [JsonPropertyName("includeAuthoredContent")]
    public bool? IncludeAuthoredContent { get; set; }

    [JsonPropertyName("insight")]
    public SubjectRightsRequestDetailModel? Insight { get; set; }

    [JsonPropertyName("internalDueDateTime")]
    public DateTime? InternalDueDateTime { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("mailboxLocations")]
    public SubjectRightsRequestMailboxLocationModel? MailboxLocations { get; set; }

    [JsonPropertyName("notes")]
    public List<AuthoredNoteModel>? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pauseAfterEstimate")]
    public bool? PauseAfterEstimate { get; set; }

    [JsonPropertyName("regulations")]
    public List<string>? Regulations { get; set; }

    [JsonPropertyName("siteLocations")]
    public SubjectRightsRequestSiteLocationModel? SiteLocations { get; set; }

    [JsonPropertyName("stages")]
    public List<SubjectRightsRequestStageDetailModel>? Stages { get; set; }

    [JsonPropertyName("status")]
    public SubjectRightsRequestStatusConstant? Status { get; set; }

    [JsonPropertyName("team")]
    public TeamModel? Team { get; set; }

    [JsonPropertyName("type")]
    public SubjectRightsRequestTypeConstant? Type { get; set; }
}
