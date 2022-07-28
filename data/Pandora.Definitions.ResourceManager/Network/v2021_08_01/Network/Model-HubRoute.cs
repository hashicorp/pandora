using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.Network;


internal class HubRouteModel
{
    [JsonPropertyName("destinationType")]
    [Required]
    public string DestinationType { get; set; }

    [JsonPropertyName("destinations")]
    [Required]
    public List<string> Destinations { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("nextHop")]
    [Required]
    public string NextHop { get; set; }

    [JsonPropertyName("nextHopType")]
    [Required]
    public string NextHopType { get; set; }
}
