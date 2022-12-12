using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.Services;


internal class PccRuleConfigurationModel
{
    [JsonPropertyName("ruleName")]
    [Required]
    public string RuleName { get; set; }

    [JsonPropertyName("rulePrecedence")]
    [Required]
    public int RulePrecedence { get; set; }

    [JsonPropertyName("ruleQosPolicy")]
    public PccRuleQosPolicyModel? RuleQosPolicy { get; set; }

    [MinItems(1)]
    [JsonPropertyName("serviceDataFlowTemplates")]
    [Required]
    public List<ServiceDataFlowTemplateModel> ServiceDataFlowTemplates { get; set; }

    [JsonPropertyName("trafficControl")]
    public TrafficControlPermissionConstant? TrafficControl { get; set; }
}
