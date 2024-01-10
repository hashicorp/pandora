// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TiIndicatorModel
{
    [JsonPropertyName("action")]
    public TiIndicatorActionConstant? Action { get; set; }

    [JsonPropertyName("activityGroupNames")]
    public List<string>? ActivityGroupNames { get; set; }

    [JsonPropertyName("additionalInformation")]
    public string? AdditionalInformation { get; set; }

    [JsonPropertyName("azureTenantId")]
    public string? AzureTenantId { get; set; }

    [JsonPropertyName("confidence")]
    public int? Confidence { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("diamondModel")]
    public TiIndicatorDiamondModelConstant? DiamondModel { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("emailEncoding")]
    public string? EmailEncoding { get; set; }

    [JsonPropertyName("emailLanguage")]
    public string? EmailLanguage { get; set; }

    [JsonPropertyName("emailRecipient")]
    public string? EmailRecipient { get; set; }

    [JsonPropertyName("emailSenderAddress")]
    public string? EmailSenderAddress { get; set; }

    [JsonPropertyName("emailSenderName")]
    public string? EmailSenderName { get; set; }

    [JsonPropertyName("emailSourceDomain")]
    public string? EmailSourceDomain { get; set; }

    [JsonPropertyName("emailSourceIpAddress")]
    public string? EmailSourceIpAddress { get; set; }

    [JsonPropertyName("emailSubject")]
    public string? EmailSubject { get; set; }

    [JsonPropertyName("emailXMailer")]
    public string? EmailXMailer { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("fileCompileDateTime")]
    public DateTime? FileCompileDateTime { get; set; }

    [JsonPropertyName("fileCreatedDateTime")]
    public DateTime? FileCreatedDateTime { get; set; }

    [JsonPropertyName("fileHashType")]
    public TiIndicatorFileHashTypeConstant? FileHashType { get; set; }

    [JsonPropertyName("fileHashValue")]
    public string? FileHashValue { get; set; }

    [JsonPropertyName("fileMutexName")]
    public string? FileMutexName { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("filePacker")]
    public string? FilePacker { get; set; }

    [JsonPropertyName("filePath")]
    public string? FilePath { get; set; }

    [JsonPropertyName("fileSize")]
    public int? FileSize { get; set; }

    [JsonPropertyName("fileType")]
    public string? FileType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ingestedDateTime")]
    public DateTime? IngestedDateTime { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("killChain")]
    public List<string>? KillChain { get; set; }

    [JsonPropertyName("knownFalsePositives")]
    public string? KnownFalsePositives { get; set; }

    [JsonPropertyName("lastReportedDateTime")]
    public DateTime? LastReportedDateTime { get; set; }

    [JsonPropertyName("malwareFamilyNames")]
    public List<string>? MalwareFamilyNames { get; set; }

    [JsonPropertyName("networkCidrBlock")]
    public string? NetworkCidrBlock { get; set; }

    [JsonPropertyName("networkDestinationAsn")]
    public int? NetworkDestinationAsn { get; set; }

    [JsonPropertyName("networkDestinationCidrBlock")]
    public string? NetworkDestinationCidrBlock { get; set; }

    [JsonPropertyName("networkDestinationIPv4")]
    public string? NetworkDestinationIPv4 { get; set; }

    [JsonPropertyName("networkDestinationIPv6")]
    public string? NetworkDestinationIPv6 { get; set; }

    [JsonPropertyName("networkDestinationPort")]
    public int? NetworkDestinationPort { get; set; }

    [JsonPropertyName("networkIPv4")]
    public string? NetworkIPv4 { get; set; }

    [JsonPropertyName("networkIPv6")]
    public string? NetworkIPv6 { get; set; }

    [JsonPropertyName("networkPort")]
    public int? NetworkPort { get; set; }

    [JsonPropertyName("networkProtocol")]
    public int? NetworkProtocol { get; set; }

    [JsonPropertyName("networkSourceAsn")]
    public int? NetworkSourceAsn { get; set; }

    [JsonPropertyName("networkSourceCidrBlock")]
    public string? NetworkSourceCidrBlock { get; set; }

    [JsonPropertyName("networkSourceIPv4")]
    public string? NetworkSourceIPv4 { get; set; }

    [JsonPropertyName("networkSourceIPv6")]
    public string? NetworkSourceIPv6 { get; set; }

    [JsonPropertyName("networkSourcePort")]
    public int? NetworkSourcePort { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passiveOnly")]
    public bool? PassiveOnly { get; set; }

    [JsonPropertyName("severity")]
    public int? Severity { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("targetProduct")]
    public string? TargetProduct { get; set; }

    [JsonPropertyName("threatType")]
    public string? ThreatType { get; set; }

    [JsonPropertyName("tlpLevel")]
    public TiIndicatorTlpLevelConstant? TlpLevel { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }
}
