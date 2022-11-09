using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2022_03_01.Pricings;


internal class PricingPropertiesModel
{
    [JsonPropertyName("deprecated")]
    public bool? Deprecated { get; set; }

    [JsonPropertyName("freeTrialRemainingTime")]
    public string? FreeTrialRemainingTime { get; set; }

    [JsonPropertyName("pricingTier")]
    [Required]
    public PricingTierConstant PricingTier { get; set; }

    [JsonPropertyName("replacedBy")]
    public List<string>? ReplacedBy { get; set; }

    [JsonPropertyName("subPlan")]
    public string? SubPlan { get; set; }
}
