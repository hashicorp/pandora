using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class HardwareInventoryModel
{
    [JsonPropertyName("additionalHostInformation")]
    public string? AdditionalHostInformation { get; set; }

    [JsonPropertyName("interfaces")]
    public List<HardwareInventoryNetworkInterfaceModel>? Interfaces { get; set; }

    [JsonPropertyName("nics")]
    public List<NicModel>? Nics { get; set; }
}
