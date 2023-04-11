using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.SecureScore;


internal class SecureScoreControlScoreDetailsModel
{
    [JsonPropertyName("definition")]
    public SecureScoreControlDefinitionItemModel? Definition { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("healthyResourceCount")]
    public int? HealthyResourceCount { get; set; }

    [JsonPropertyName("notApplicableResourceCount")]
    public int? NotApplicableResourceCount { get; set; }

    [JsonPropertyName("score")]
    public ScoreDetailsModel? Score { get; set; }

    [JsonPropertyName("unhealthyResourceCount")]
    public int? UnhealthyResourceCount { get; set; }

    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
}
