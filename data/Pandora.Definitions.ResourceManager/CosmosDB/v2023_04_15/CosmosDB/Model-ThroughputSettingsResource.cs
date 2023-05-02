using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_04_15.CosmosDB;


internal class ThroughputSettingsResourceModel
{
    [JsonPropertyName("autoscaleSettings")]
    public AutoscaleSettingsResourceModel? AutoScaleSettings { get; set; }

    [JsonPropertyName("instantMaximumThroughput")]
    public string? InstantMaximumThroughput { get; set; }

    [JsonPropertyName("minimumThroughput")]
    public string? MinimumThroughput { get; set; }

    [JsonPropertyName("offerReplacePending")]
    public string? OfferReplacePending { get; set; }

    [JsonPropertyName("softAllowedMaximumThroughput")]
    public string? SoftAllowedMaximumThroughput { get; set; }

    [JsonPropertyName("throughput")]
    public int? Throughput { get; set; }
}
