using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2024_01_01.Pricings;


internal class PricingPropertiesModel
{
    [JsonPropertyName("deprecated")]
    public bool? Deprecated { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("enablementTime")]
    public DateTime? EnablementTime { get; set; }

    [JsonPropertyName("enforce")]
    public EnforceConstant? Enforce { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("freeTrialRemainingTime")]
    public string? FreeTrialRemainingTime { get; set; }

    [JsonPropertyName("inherited")]
    public InheritedConstant? Inherited { get; set; }

    [JsonPropertyName("inheritedFrom")]
    public string? InheritedFrom { get; set; }

    [JsonPropertyName("pricingTier")]
    [Required]
    public PricingTierConstant PricingTier { get; set; }

    [JsonPropertyName("replacedBy")]
    public List<string>? ReplacedBy { get; set; }

    [JsonPropertyName("resourcesCoverageStatus")]
    public ResourcesCoverageStatusConstant? ResourcesCoverageStatus { get; set; }

    [JsonPropertyName("subPlan")]
    public string? SubPlan { get; set; }
}
