using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNSResolver.v2022_07_01.ForwardingRules;


internal class ForwardingRulePropertiesModel
{
    [JsonPropertyName("domainName")]
    [Required]
    public string DomainName { get; set; }

    [JsonPropertyName("forwardingRuleState")]
    public ForwardingRuleStateConstant? ForwardingRuleState { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("targetDnsServers")]
    [Required]
    public List<TargetDnsServerModel> TargetDnsServers { get; set; }
}
