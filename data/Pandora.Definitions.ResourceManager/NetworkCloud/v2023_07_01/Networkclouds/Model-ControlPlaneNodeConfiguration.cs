using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ControlPlaneNodeConfigurationModel
{
    [JsonPropertyName("administratorConfiguration")]
    public AdministratorConfigurationModel? AdministratorConfiguration { get; set; }

    [JsonPropertyName("availabilityZones")]
    public CustomTypes.Zones? AvailabilityZones { get; set; }

    [JsonPropertyName("count")]
    [Required]
    public int Count { get; set; }

    [JsonPropertyName("vmSkuName")]
    [Required]
    public string VMSkuName { get; set; }
}
