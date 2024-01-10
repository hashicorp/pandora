// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationAssignmentModel
{
    [JsonPropertyName("addToCalendarAction")]
    public EducationAssignmentAddToCalendarActionConstant? AddToCalendarAction { get; set; }

    [JsonPropertyName("addedStudentAction")]
    public EducationAssignmentAddedStudentActionConstant? AddedStudentAction { get; set; }

    [JsonPropertyName("allowLateSubmissions")]
    public bool? AllowLateSubmissions { get; set; }

    [JsonPropertyName("allowStudentsToAddResourcesToSubmission")]
    public bool? AllowStudentsToAddResourcesToSubmission { get; set; }

    [JsonPropertyName("assignDateTime")]
    public DateTime? AssignDateTime { get; set; }

    [JsonPropertyName("assignTo")]
    public EducationAssignmentRecipientModel? AssignTo { get; set; }

    [JsonPropertyName("assignedDateTime")]
    public DateTime? AssignedDateTime { get; set; }

    [JsonPropertyName("categories")]
    public List<EducationCategoryModel>? Categories { get; set; }

    [JsonPropertyName("classId")]
    public string? ClassId { get; set; }

    [JsonPropertyName("closeDateTime")]
    public DateTime? CloseDateTime { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("dueDateTime")]
    public DateTime? DueDateTime { get; set; }

    [JsonPropertyName("feedbackResourcesFolderUrl")]
    public string? FeedbackResourcesFolderUrl { get; set; }

    [JsonPropertyName("grading")]
    public EducationAssignmentGradeTypeModel? Grading { get; set; }

    [JsonPropertyName("gradingCategory")]
    public EducationGradingCategoryModel? GradingCategory { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("instructions")]
    public EducationItemBodyModel? Instructions { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("moduleUrl")]
    public string? ModuleUrl { get; set; }

    [JsonPropertyName("notificationChannelUrl")]
    public string? NotificationChannelUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resources")]
    public List<EducationAssignmentResourceModel>? Resources { get; set; }

    [JsonPropertyName("resourcesFolderUrl")]
    public string? ResourcesFolderUrl { get; set; }

    [JsonPropertyName("rubric")]
    public EducationRubricModel? Rubric { get; set; }

    [JsonPropertyName("status")]
    public EducationAssignmentStatusConstant? Status { get; set; }

    [JsonPropertyName("submissions")]
    public List<EducationSubmissionModel>? Submissions { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
