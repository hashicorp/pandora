using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ApplicationGateways;


internal class ApplicationGatewayWebApplicationFirewallConfigurationModel
{
    [JsonPropertyName("disabledRuleGroups")]
    public List<ApplicationGatewayFirewallDisabledRuleGroupModel>? DisabledRuleGroups { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public bool Enabled { get; set; }

    [JsonPropertyName("exclusions")]
    public List<ApplicationGatewayFirewallExclusionModel>? Exclusions { get; set; }

    [JsonPropertyName("fileUploadLimitInMb")]
    public int? FileUploadLimitInMb { get; set; }

    [JsonPropertyName("firewallMode")]
    [Required]
    public ApplicationGatewayFirewallModeConstant FirewallMode { get; set; }

    [JsonPropertyName("maxRequestBodySize")]
    public int? MaxRequestBodySize { get; set; }

    [JsonPropertyName("maxRequestBodySizeInKb")]
    public int? MaxRequestBodySizeInKb { get; set; }

    [JsonPropertyName("requestBodyCheck")]
    public bool? RequestBodyCheck { get; set; }

    [JsonPropertyName("ruleSetType")]
    [Required]
    public string RuleSetType { get; set; }

    [JsonPropertyName("ruleSetVersion")]
    [Required]
    public string RuleSetVersion { get; set; }
}
