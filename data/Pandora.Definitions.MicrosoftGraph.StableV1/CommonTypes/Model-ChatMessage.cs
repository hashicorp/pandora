// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ChatMessageModel
{
    [JsonPropertyName("attachments")]
    public List<ChatMessageAttachmentModel>? Attachments { get; set; }

    [JsonPropertyName("body")]
    public ItemBodyModel? Body { get; set; }

    [JsonPropertyName("channelIdentity")]
    public ChannelIdentityModel? ChannelIdentity { get; set; }

    [JsonPropertyName("chatId")]
    public string? ChatId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("eventDetail")]
    public EventMessageDetailModel? EventDetail { get; set; }

    [JsonPropertyName("from")]
    public ChatMessageFromIdentitySetModel? From { get; set; }

    [JsonPropertyName("hostedContents")]
    public List<ChatMessageHostedContentModel>? HostedContents { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importance")]
    public ChatMessageImportanceConstant? Importance { get; set; }

    [JsonPropertyName("lastEditedDateTime")]
    public DateTime? LastEditedDateTime { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("mentions")]
    public List<ChatMessageMentionModel>? Mentions { get; set; }

    [JsonPropertyName("messageHistory")]
    public List<ChatMessageHistoryItemModel>? MessageHistory { get; set; }

    [JsonPropertyName("messageType")]
    public ChatMessageTypeConstant? MessageType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyViolation")]
    public ChatMessagePolicyViolationModel? PolicyViolation { get; set; }

    [JsonPropertyName("reactions")]
    public List<ChatMessageReactionModel>? Reactions { get; set; }

    [JsonPropertyName("replies")]
    public List<ChatMessageModel>? Replies { get; set; }

    [JsonPropertyName("replyToId")]
    public string? ReplyToId { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
