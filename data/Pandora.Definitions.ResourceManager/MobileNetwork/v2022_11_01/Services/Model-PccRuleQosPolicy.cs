using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.Services;


internal class PccRuleQosPolicyModel
{
    [JsonPropertyName("allocationAndRetentionPriorityLevel")]
    public int? AllocationAndRetentionPriorityLevel { get; set; }

    [JsonPropertyName("5qi")]
    public int? Fiveqi { get; set; }

    [JsonPropertyName("guaranteedBitRate")]
    public AmbrModel? GuaranteedBitRate { get; set; }

    [JsonPropertyName("maximumBitRate")]
    [Required]
    public AmbrModel MaximumBitRate { get; set; }

    [JsonPropertyName("preemptionCapability")]
    public PreemptionCapabilityConstant? PreemptionCapability { get; set; }

    [JsonPropertyName("preemptionVulnerability")]
    public PreemptionVulnerabilityConstant? PreemptionVulnerability { get; set; }
}
