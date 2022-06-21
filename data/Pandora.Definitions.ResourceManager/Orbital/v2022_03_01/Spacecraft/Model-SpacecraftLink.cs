using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.Spacecraft;


internal class SpacecraftLinkModel
{
    [JsonPropertyName("authorizations")]
    public List<AuthorizedGroundstationModel>? Authorizations { get; set; }

    [JsonPropertyName("bandwidthMHz")]
    [Required]
    public float BandwidthMHz { get; set; }

    [JsonPropertyName("centerFrequencyMHz")]
    [Required]
    public float CenterFrequencyMHz { get; set; }

    [JsonPropertyName("direction")]
    [Required]
    public DirectionConstant Direction { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("polarization")]
    [Required]
    public PolarizationConstant Polarization { get; set; }
}
