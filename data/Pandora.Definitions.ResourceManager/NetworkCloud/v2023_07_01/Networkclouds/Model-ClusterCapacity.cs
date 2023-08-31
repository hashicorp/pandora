using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ClusterCapacityModel
{
    [JsonPropertyName("availableApplianceStorageGB")]
    public int? AvailableApplianceStorageGB { get; set; }

    [JsonPropertyName("availableCoreCount")]
    public int? AvailableCoreCount { get; set; }

    [JsonPropertyName("availableHostStorageGB")]
    public int? AvailableHostStorageGB { get; set; }

    [JsonPropertyName("availableMemoryGB")]
    public int? AvailableMemoryGB { get; set; }

    [JsonPropertyName("totalApplianceStorageGB")]
    public int? TotalApplianceStorageGB { get; set; }

    [JsonPropertyName("totalCoreCount")]
    public int? TotalCoreCount { get; set; }

    [JsonPropertyName("totalHostStorageGB")]
    public int? TotalHostStorageGB { get; set; }

    [JsonPropertyName("totalMemoryGB")]
    public int? TotalMemoryGB { get; set; }
}
