using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CognitiveServicesAccounts;


internal class SkuAvailabilityModel
{
    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("skuAvailable")]
    public bool? SkuAvailable { get; set; }

    [JsonPropertyName("skuName")]
    public string? SkuName { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
