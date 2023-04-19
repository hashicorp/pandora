using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Subscriptions;


internal class LocationMetadataModel
{
    [JsonPropertyName("geography")]
    public string? Geography { get; set; }

    [JsonPropertyName("geographyGroup")]
    public string? GeographyGroup { get; set; }

    [JsonPropertyName("homeLocation")]
    public string? HomeLocation { get; set; }

    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    [JsonPropertyName("pairedRegion")]
    public List<PairedRegionModel>? PairedRegion { get; set; }

    [JsonPropertyName("physicalLocation")]
    public string? PhysicalLocation { get; set; }

    [JsonPropertyName("regionCategory")]
    public RegionCategoryConstant? RegionCategory { get; set; }

    [JsonPropertyName("regionType")]
    public RegionTypeConstant? RegionType { get; set; }
}
