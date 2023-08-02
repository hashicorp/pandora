// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EventMessageModel
{
    [JsonPropertyName("attachments")]
    public List<AttachmentModel>? Attachments { get; set; }

    [JsonPropertyName("bccRecipients")]
    public List<RecipientModel>? BccRecipients { get; set; }

    [JsonPropertyName("body")]
    public ItemBodyModel? Body { get; set; }

    [JsonPropertyName("bodyPreview")]
    public string? BodyPreview { get; set; }

    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("ccRecipients")]
    public List<RecipientModel>? CcRecipients { get; set; }

    [JsonPropertyName("changeKey")]
    public string? ChangeKey { get; set; }

    [JsonPropertyName("conversationId")]
    public string? ConversationId { get; set; }

    [JsonPropertyName("conversationIndex")]
    public string? ConversationIndex { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTimeTimeZoneModel? EndDateTime { get; set; }

    [JsonPropertyName("event")]
    public EventModel? Event { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("flag")]
    public FollowupFlagModel? Flag { get; set; }

    [JsonPropertyName("from")]
    public RecipientModel? From { get; set; }

    [JsonPropertyName("hasAttachments")]
    public bool? HasAttachments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importance")]
    public ImportanceConstant? Importance { get; set; }

    [JsonPropertyName("inferenceClassification")]
    public InferenceClassificationTypeConstant? InferenceClassification { get; set; }

    [JsonPropertyName("internetMessageHeaders")]
    public List<InternetMessageHeaderModel>? InternetMessageHeaders { get; set; }

    [JsonPropertyName("internetMessageId")]
    public string? InternetMessageId { get; set; }

    [JsonPropertyName("isAllDay")]
    public bool? IsAllDay { get; set; }

    [JsonPropertyName("isDelegated")]
    public bool? IsDelegated { get; set; }

    [JsonPropertyName("isDeliveryReceiptRequested")]
    public bool? IsDeliveryReceiptRequested { get; set; }

    [JsonPropertyName("isDraft")]
    public bool? IsDraft { get; set; }

    [JsonPropertyName("isOutOfDate")]
    public bool? IsOutOfDate { get; set; }

    [JsonPropertyName("isRead")]
    public bool? IsRead { get; set; }

    [JsonPropertyName("isReadReceiptRequested")]
    public bool? IsReadReceiptRequested { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("location")]
    public LocationModel? Location { get; set; }

    [JsonPropertyName("meetingMessageType")]
    public MeetingMessageTypeConstant? MeetingMessageType { get; set; }

    [JsonPropertyName("multiValueExtendedProperties")]
    public List<MultiValueLegacyExtendedPropertyModel>? MultiValueExtendedProperties { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentFolderId")]
    public string? ParentFolderId { get; set; }

    [JsonPropertyName("receivedDateTime")]
    public DateTime? ReceivedDateTime { get; set; }

    [JsonPropertyName("recurrence")]
    public PatternedRecurrenceModel? Recurrence { get; set; }

    [JsonPropertyName("replyTo")]
    public List<RecipientModel>? ReplyTo { get; set; }

    [JsonPropertyName("sender")]
    public RecipientModel? Sender { get; set; }

    [JsonPropertyName("sentDateTime")]
    public DateTime? SentDateTime { get; set; }

    [JsonPropertyName("singleValueExtendedProperties")]
    public List<SingleValueLegacyExtendedPropertyModel>? SingleValueExtendedProperties { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTimeTimeZoneModel? StartDateTime { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("toRecipients")]
    public List<RecipientModel>? ToRecipients { get; set; }

    [JsonPropertyName("type")]
    public EventTypeConstant? Type { get; set; }

    [JsonPropertyName("uniqueBody")]
    public ItemBodyModel? UniqueBody { get; set; }

    [JsonPropertyName("webLink")]
    public string? WebLink { get; set; }
}
