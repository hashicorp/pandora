using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2023_05_01.CognitiveServicesAccounts;


internal class ModelSkuModel
{
    [JsonPropertyName("capacity")]
    public CapacityConfigModel? Capacity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("deprecationDate")]
    public DateTime? DeprecationDate { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("rateLimits")]
    public List<CallRateLimitModel>? RateLimits { get; set; }

    [JsonPropertyName("usageName")]
    public string? UsageName { get; set; }
}
