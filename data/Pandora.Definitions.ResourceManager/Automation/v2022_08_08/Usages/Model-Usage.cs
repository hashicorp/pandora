using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.Usages;


internal class UsageModel
{
    [JsonPropertyName("currentValue")]
    public float? CurrentValue { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("name")]
    public UsageCounterNameModel? Name { get; set; }

    [JsonPropertyName("throttleStatus")]
    public string? ThrottleStatus { get; set; }

    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
}
