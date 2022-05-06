using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Locations;


internal class CapabilityInformationModel
{
    [JsonPropertyName("accountCount")]
    public int? AccountCount { get; set; }

    [JsonPropertyName("maxAccountCount")]
    public int? MaxAccountCount { get; set; }

    [JsonPropertyName("migrationState")]
    public bool? MigrationState { get; set; }

    [JsonPropertyName("state")]
    public SubscriptionStateConstant? State { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }
}
