// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MailTipsModel
{
    [JsonPropertyName("automaticReplies")]
    public AutomaticRepliesMailTipsModel? AutomaticReplies { get; set; }

    [JsonPropertyName("customMailTip")]
    public string? CustomMailTip { get; set; }

    [JsonPropertyName("deliveryRestricted")]
    public bool? DeliveryRestricted { get; set; }

    [JsonPropertyName("emailAddress")]
    public EmailAddressModel? EmailAddress { get; set; }

    [JsonPropertyName("error")]
    public MailTipsErrorModel? Error { get; set; }

    [JsonPropertyName("externalMemberCount")]
    public int? ExternalMemberCount { get; set; }

    [JsonPropertyName("isModerated")]
    public bool? IsModerated { get; set; }

    [JsonPropertyName("mailboxFull")]
    public bool? MailboxFull { get; set; }

    [JsonPropertyName("maxMessageSize")]
    public int? MaxMessageSize { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recipientScope")]
    public RecipientScopeTypeConstant? RecipientScope { get; set; }

    [JsonPropertyName("recipientSuggestions")]
    public List<RecipientModel>? RecipientSuggestions { get; set; }

    [JsonPropertyName("totalMemberCount")]
    public int? TotalMemberCount { get; set; }
}
