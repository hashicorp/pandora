using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class NetworkInterfaceModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("deviceConnectionType")]
    public DeviceConnectionTypeConstant? DeviceConnectionType { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("physicalSlot")]
    public int? PhysicalSlot { get; set; }

    [JsonPropertyName("portCount")]
    public int? PortCount { get; set; }

    [JsonPropertyName("portSpeed")]
    public int? PortSpeed { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }
}
