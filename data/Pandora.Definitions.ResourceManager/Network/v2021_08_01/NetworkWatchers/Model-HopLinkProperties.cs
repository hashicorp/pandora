using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkWatchers;


internal class HopLinkPropertiesModel
{
    [JsonPropertyName("roundTripTimeAvg")]
    public int? RoundTripTimeAvg { get; set; }

    [JsonPropertyName("roundTripTimeMax")]
    public int? RoundTripTimeMax { get; set; }

    [JsonPropertyName("roundTripTimeMin")]
    public int? RoundTripTimeMin { get; set; }
}
