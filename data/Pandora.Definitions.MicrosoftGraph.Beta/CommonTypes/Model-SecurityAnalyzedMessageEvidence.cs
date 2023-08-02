// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityAnalyzedMessageEvidenceModel
{
    [JsonPropertyName("antiSpamDirection")]
    public string? AntiSpamDirection { get; set; }

    [JsonPropertyName("attachmentsCount")]
    public long? AttachmentsCount { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deliveryAction")]
    public string? DeliveryAction { get; set; }

    [JsonPropertyName("deliveryLocation")]
    public string? DeliveryLocation { get; set; }

    [JsonPropertyName("detailedRoles")]
    public List<string>? DetailedRoles { get; set; }

    [JsonPropertyName("internetMessageId")]
    public string? InternetMessageId { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("networkMessageId")]
    public string? NetworkMessageId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("p1Sender")]
    public EmailSenderModel? P1Sender { get; set; }

    [JsonPropertyName("p2Sender")]
    public EmailSenderModel? P2Sender { get; set; }

    [JsonPropertyName("receivedDateTime")]
    public DateTime? ReceivedDateTime { get; set; }

    [JsonPropertyName("recipientEmailAddress")]
    public string? RecipientEmailAddress { get; set; }

    [JsonPropertyName("remediationStatus")]
    public EvidenceRemediationStatusConstant? RemediationStatus { get; set; }

    [JsonPropertyName("remediationStatusDetails")]
    public string? RemediationStatusDetails { get; set; }

    [JsonPropertyName("roles")]
    public List<EvidenceRoleConstant>? Roles { get; set; }

    [JsonPropertyName("senderIp")]
    public string? SenderIp { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("threatDetectionMethods")]
    public List<string>? ThreatDetectionMethods { get; set; }

    [JsonPropertyName("threats")]
    public List<string>? Threats { get; set; }

    [JsonPropertyName("urlCount")]
    public long? UrlCount { get; set; }

    [JsonPropertyName("urls")]
    public List<string>? Urls { get; set; }

    [JsonPropertyName("urn")]
    public string? Urn { get; set; }

    [JsonPropertyName("verdict")]
    public EvidenceVerdictConstant? Verdict { get; set; }
}
