using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.PrivateClouds;


internal class CircuitModel
{
    [JsonPropertyName("expressRouteID")]
    public string? ExpressRouteID { get; set; }

    [JsonPropertyName("expressRoutePrivatePeeringID")]
    public string? ExpressRoutePrivatePeeringID { get; set; }

    [JsonPropertyName("primarySubnet")]
    public string? PrimarySubnet { get; set; }

    [JsonPropertyName("secondarySubnet")]
    public string? SecondarySubnet { get; set; }
}
