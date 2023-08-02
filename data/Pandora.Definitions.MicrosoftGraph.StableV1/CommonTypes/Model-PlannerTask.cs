// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PlannerTaskModel
{
    [JsonPropertyName("activeChecklistItemCount")]
    public int? ActiveChecklistItemCount { get; set; }

    [JsonPropertyName("appliedCategories")]
    public PlannerAppliedCategoriesModel? AppliedCategories { get; set; }

    [JsonPropertyName("assignedToTaskBoardFormat")]
    public PlannerAssignedToTaskBoardTaskFormatModel? AssignedToTaskBoardFormat { get; set; }

    [JsonPropertyName("assigneePriority")]
    public string? AssigneePriority { get; set; }

    [JsonPropertyName("assignments")]
    public PlannerAssignmentsModel? Assignments { get; set; }

    [JsonPropertyName("bucketId")]
    public string? BucketId { get; set; }

    [JsonPropertyName("bucketTaskBoardFormat")]
    public PlannerBucketTaskBoardTaskFormatModel? BucketTaskBoardFormat { get; set; }

    [JsonPropertyName("checklistItemCount")]
    public int? ChecklistItemCount { get; set; }

    [JsonPropertyName("completedBy")]
    public IdentitySetModel? CompletedBy { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("conversationThreadId")]
    public string? ConversationThreadId { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("details")]
    public PlannerTaskDetailsModel? Details { get; set; }

    [JsonPropertyName("dueDateTime")]
    public DateTime? DueDateTime { get; set; }

    [JsonPropertyName("hasDescription")]
    public bool? HasDescription { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("orderHint")]
    public string? OrderHint { get; set; }

    [JsonPropertyName("percentComplete")]
    public int? PercentComplete { get; set; }

    [JsonPropertyName("planId")]
    public string? PlanId { get; set; }

    [JsonPropertyName("previewType")]
    public PlannerPreviewTypeConstant? PreviewType { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("progressTaskBoardFormat")]
    public PlannerProgressTaskBoardTaskFormatModel? ProgressTaskBoardFormat { get; set; }

    [JsonPropertyName("referenceCount")]
    public int? ReferenceCount { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
