using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.GroundStation;


internal class AvailableGroundStationPropertiesModel
{
    [JsonPropertyName("altitudeMeters")]
    public float? AltitudeMeters { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("latitudeDegrees")]
    public float? LatitudeDegrees { get; set; }

    [JsonPropertyName("longitudeDegrees")]
    public float? LongitudeDegrees { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }

    [JsonPropertyName("releaseMode")]
    public ReleaseModeConstant? ReleaseMode { get; set; }
}
