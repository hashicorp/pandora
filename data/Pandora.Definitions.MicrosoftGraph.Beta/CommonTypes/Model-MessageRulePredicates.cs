// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MessageRulePredicatesModel
{
    [JsonPropertyName("bodyContains")]
    public List<string>? BodyContains { get; set; }

    [JsonPropertyName("bodyOrSubjectContains")]
    public List<string>? BodyOrSubjectContains { get; set; }

    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("fromAddresses")]
    public List<RecipientModel>? FromAddresses { get; set; }

    [JsonPropertyName("hasAttachments")]
    public bool? HasAttachments { get; set; }

    [JsonPropertyName("headerContains")]
    public List<string>? HeaderContains { get; set; }

    [JsonPropertyName("importance")]
    public ImportanceConstant? Importance { get; set; }

    [JsonPropertyName("isApprovalRequest")]
    public bool? IsApprovalRequest { get; set; }

    [JsonPropertyName("isAutomaticForward")]
    public bool? IsAutomaticForward { get; set; }

    [JsonPropertyName("isAutomaticReply")]
    public bool? IsAutomaticReply { get; set; }

    [JsonPropertyName("isEncrypted")]
    public bool? IsEncrypted { get; set; }

    [JsonPropertyName("isMeetingRequest")]
    public bool? IsMeetingRequest { get; set; }

    [JsonPropertyName("isMeetingResponse")]
    public bool? IsMeetingResponse { get; set; }

    [JsonPropertyName("isNonDeliveryReport")]
    public bool? IsNonDeliveryReport { get; set; }

    [JsonPropertyName("isPermissionControlled")]
    public bool? IsPermissionControlled { get; set; }

    [JsonPropertyName("isReadReceipt")]
    public bool? IsReadReceipt { get; set; }

    [JsonPropertyName("isSigned")]
    public bool? IsSigned { get; set; }

    [JsonPropertyName("isVoicemail")]
    public bool? IsVoicemail { get; set; }

    [JsonPropertyName("messageActionFlag")]
    public MessageActionFlagConstant? MessageActionFlag { get; set; }

    [JsonPropertyName("notSentToMe")]
    public bool? NotSentToMe { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recipientContains")]
    public List<string>? RecipientContains { get; set; }

    [JsonPropertyName("senderContains")]
    public List<string>? SenderContains { get; set; }

    [JsonPropertyName("sensitivity")]
    public SensitivityConstant? Sensitivity { get; set; }

    [JsonPropertyName("sentCcMe")]
    public bool? SentCcMe { get; set; }

    [JsonPropertyName("sentOnlyToMe")]
    public bool? SentOnlyToMe { get; set; }

    [JsonPropertyName("sentToAddresses")]
    public List<RecipientModel>? SentToAddresses { get; set; }

    [JsonPropertyName("sentToMe")]
    public bool? SentToMe { get; set; }

    [JsonPropertyName("sentToOrCcMe")]
    public bool? SentToOrCcMe { get; set; }

    [JsonPropertyName("subjectContains")]
    public List<string>? SubjectContains { get; set; }

    [JsonPropertyName("withinSizeRange")]
    public SizeRangeModel? WithinSizeRange { get; set; }
}
