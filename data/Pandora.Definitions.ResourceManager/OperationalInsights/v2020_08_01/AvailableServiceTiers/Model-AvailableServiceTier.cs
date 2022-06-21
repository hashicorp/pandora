using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.AvailableServiceTiers;


internal class AvailableServiceTierModel
{
    [JsonPropertyName("capacityReservationLevel")]
    public int? CapacityReservationLevel { get; set; }

    [JsonPropertyName("defaultRetention")]
    public int? DefaultRetention { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("lastSkuUpdate")]
    public string? LastSkuUpdate { get; set; }

    [JsonPropertyName("maximumRetention")]
    public int? MaximumRetention { get; set; }

    [JsonPropertyName("minimumRetention")]
    public int? MinimumRetention { get; set; }

    [JsonPropertyName("serviceTier")]
    public SkuNameEnumConstant? ServiceTier { get; set; }
}
