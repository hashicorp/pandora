using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.ContactProfile;


internal class ContactProfileLinkChannelModel
{
    [JsonPropertyName("bandwidthMHz")]
    [Required]
    public float BandwidthMHz { get; set; }

    [JsonPropertyName("centerFrequencyMHz")]
    [Required]
    public float CenterFrequencyMHz { get; set; }

    [JsonPropertyName("decodingConfiguration")]
    public string? DecodingConfiguration { get; set; }

    [JsonPropertyName("demodulationConfiguration")]
    public string? DemodulationConfiguration { get; set; }

    [JsonPropertyName("encodingConfiguration")]
    public string? EncodingConfiguration { get; set; }

    [JsonPropertyName("endPoint")]
    [Required]
    public EndPointModel EndPoint { get; set; }

    [JsonPropertyName("modulationConfiguration")]
    public string? ModulationConfiguration { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
