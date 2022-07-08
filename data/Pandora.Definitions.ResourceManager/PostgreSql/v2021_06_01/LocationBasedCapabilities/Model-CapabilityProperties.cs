using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2021_06_01.LocationBasedCapabilities;


internal class CapabilityPropertiesModel
{
    [JsonPropertyName("geoBackupSupported")]
    public bool? GeoBackupSupported { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("supportedFlexibleServerEditions")]
    public List<FlexibleServerEditionCapabilityModel>? SupportedFlexibleServerEditions { get; set; }

    [JsonPropertyName("supportedHAMode")]
    public List<string>? SupportedHAMode { get; set; }

    [JsonPropertyName("supportedHyperscaleNodeEditions")]
    public List<HyperscaleNodeEditionCapabilityModel>? SupportedHyperscaleNodeEditions { get; set; }

    [JsonPropertyName("zone")]
    public string? Zone { get; set; }

    [JsonPropertyName("zoneRedundantHaAndGeoBackupSupported")]
    public bool? ZoneRedundantHaAndGeoBackupSupported { get; set; }

    [JsonPropertyName("zoneRedundantHaSupported")]
    public bool? ZoneRedundantHaSupported { get; set; }
}
