// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TodoTaskModel
{
    [JsonPropertyName("attachmentSessions")]
    public List<AttachmentSessionModel>? AttachmentSessions { get; set; }

    [JsonPropertyName("attachments")]
    public List<AttachmentBaseModel>? Attachments { get; set; }

    [JsonPropertyName("body")]
    public ItemBodyModel? Body { get; set; }

    [JsonPropertyName("bodyLastModifiedDateTime")]
    public DateTime? BodyLastModifiedDateTime { get; set; }

    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("checklistItems")]
    public List<ChecklistItemModel>? ChecklistItems { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTimeTimeZoneModel? CompletedDateTime { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dueDateTime")]
    public DateTimeTimeZoneModel? DueDateTime { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("hasAttachments")]
    public bool? HasAttachments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importance")]
    public TodoTaskImportanceConstant? Importance { get; set; }

    [JsonPropertyName("isReminderOn")]
    public bool? IsReminderOn { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("linkedResources")]
    public List<LinkedResourceModel>? LinkedResources { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recurrence")]
    public PatternedRecurrenceModel? Recurrence { get; set; }

    [JsonPropertyName("reminderDateTime")]
    public DateTimeTimeZoneModel? ReminderDateTime { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTimeTimeZoneModel? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public TodoTaskStatusConstant? Status { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
