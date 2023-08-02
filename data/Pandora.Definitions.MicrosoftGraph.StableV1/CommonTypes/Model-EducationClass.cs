// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EducationClassModel
{
    [JsonPropertyName("assignmentCategories")]
    public List<EducationCategoryModel>? AssignmentCategories { get; set; }

    [JsonPropertyName("assignmentDefaults")]
    public EducationAssignmentDefaultsModel? AssignmentDefaults { get; set; }

    [JsonPropertyName("assignmentSettings")]
    public EducationAssignmentSettingsModel? AssignmentSettings { get; set; }

    [JsonPropertyName("assignments")]
    public List<EducationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("classCode")]
    public string? ClassCode { get; set; }

    [JsonPropertyName("course")]
    public EducationCourseModel? Course { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("externalName")]
    public string? ExternalName { get; set; }

    [JsonPropertyName("externalSource")]
    public EducationExternalSourceConstant? ExternalSource { get; set; }

    [JsonPropertyName("externalSourceDetail")]
    public string? ExternalSourceDetail { get; set; }

    [JsonPropertyName("grade")]
    public string? Grade { get; set; }

    [JsonPropertyName("group")]
    public GroupModel? Group { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("mailNickname")]
    public string? MailNickname { get; set; }

    [JsonPropertyName("members")]
    public List<EducationUserModel>? Members { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schools")]
    public List<EducationSchoolModel>? Schools { get; set; }

    [JsonPropertyName("teachers")]
    public List<EducationUserModel>? Teachers { get; set; }

    [JsonPropertyName("term")]
    public EducationTermModel? Term { get; set; }
}
