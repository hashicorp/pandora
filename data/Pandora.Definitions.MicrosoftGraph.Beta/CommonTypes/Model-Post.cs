// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PostModel
{
    [JsonPropertyName("attachments")]
    public List<AttachmentModel>? Attachments { get; set; }

    [JsonPropertyName("body")]
    public ItemBodyModel? Body { get; set; }

    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("changeKey")]
    public string? ChangeKey { get; set; }

    [JsonPropertyName("conversationId")]
    public string? ConversationId { get; set; }

    [JsonPropertyName("conversationThreadId")]
    public string? ConversationThreadId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("from")]
    public RecipientModel? From { get; set; }

    [JsonPropertyName("hasAttachments")]
    public bool? HasAttachments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importance")]
    public PostImportanceConstant? Importance { get; set; }

    [JsonPropertyName("inReplyTo")]
    public PostModel? InReplyTo { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("mentions")]
    public List<MentionModel>? Mentions { get; set; }

    [JsonPropertyName("multiValueExtendedProperties")]
    public List<MultiValueLegacyExtendedPropertyModel>? MultiValueExtendedProperties { get; set; }

    [JsonPropertyName("newParticipants")]
    public List<RecipientModel>? NewParticipants { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("receivedDateTime")]
    public DateTime? ReceivedDateTime { get; set; }

    [JsonPropertyName("sender")]
    public RecipientModel? Sender { get; set; }

    [JsonPropertyName("singleValueExtendedProperties")]
    public List<SingleValueLegacyExtendedPropertyModel>? SingleValueExtendedProperties { get; set; }
}
