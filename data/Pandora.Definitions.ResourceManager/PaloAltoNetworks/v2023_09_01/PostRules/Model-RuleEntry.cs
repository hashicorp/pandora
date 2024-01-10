using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.PostRules;


internal class RuleEntryModel
{
    [JsonPropertyName("actionType")]
    public ActionEnumConstant? ActionType { get; set; }

    [JsonPropertyName("applications")]
    public List<string>? Applications { get; set; }

    [JsonPropertyName("auditComment")]
    public string? AuditComment { get; set; }

    [JsonPropertyName("category")]
    public CategoryModel? Category { get; set; }

    [JsonPropertyName("decryptionRuleType")]
    public DecryptionRuleTypeEnumConstant? DecryptionRuleType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("destination")]
    public DestinationAddrModel? Destination { get; set; }

    [JsonPropertyName("enableLogging")]
    public StateEnumConstant? EnableLogging { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("inboundInspectionCertificate")]
    public string? InboundInspectionCertificate { get; set; }

    [JsonPropertyName("negateDestination")]
    public BooleanEnumConstant? NegateDestination { get; set; }

    [JsonPropertyName("negateSource")]
    public BooleanEnumConstant? NegateSource { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("protocol")]
    public string? Protocol { get; set; }

    [JsonPropertyName("protocolPortList")]
    public List<string>? ProtocolPortList { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("ruleName")]
    [Required]
    public string RuleName { get; set; }

    [JsonPropertyName("ruleState")]
    public StateEnumConstant? RuleState { get; set; }

    [JsonPropertyName("source")]
    public SourceAddrModel? Source { get; set; }

    [JsonPropertyName("tags")]
    public List<TagInfoModel>? Tags { get; set; }
}
