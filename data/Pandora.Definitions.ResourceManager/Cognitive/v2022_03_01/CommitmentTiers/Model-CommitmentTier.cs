using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_03_01.CommitmentTiers;


internal class CommitmentTierModel
{
    [JsonPropertyName("cost")]
    public CommitmentCostModel? Cost { get; set; }

    [JsonPropertyName("hostingModel")]
    public HostingModelConstant? HostingModel { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("maxCount")]
    public int? MaxCount { get; set; }

    [JsonPropertyName("planType")]
    public string? PlanType { get; set; }

    [JsonPropertyName("quota")]
    public CommitmentQuotaModel? Quota { get; set; }

    [JsonPropertyName("skuName")]
    public string? SkuName { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }
}
