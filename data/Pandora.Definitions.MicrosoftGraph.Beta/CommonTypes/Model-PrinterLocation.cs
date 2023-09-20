// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrinterLocationModel
{
    [JsonPropertyName("altitudeInMeters")]
    public int? AltitudeInMeters { get; set; }

    [JsonPropertyName("building")]
    public string? Building { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("countryOrRegion")]
    public string? CountryOrRegion { get; set; }

    [JsonPropertyName("floor")]
    public string? Floor { get; set; }

    [JsonPropertyName("floorDescription")]
    public string? FloorDescription { get; set; }

    [JsonPropertyName("floorNumber")]
    public int? FloorNumber { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organization")]
    public List<string>? Organization { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("roomDescription")]
    public string? RoomDescription { get; set; }

    [JsonPropertyName("roomName")]
    public string? RoomName { get; set; }

    [JsonPropertyName("roomNumber")]
    public int? RoomNumber { get; set; }

    [JsonPropertyName("site")]
    public string? Site { get; set; }

    [JsonPropertyName("stateOrProvince")]
    public string? StateOrProvince { get; set; }

    [JsonPropertyName("streetAddress")]
    public string? StreetAddress { get; set; }

    [JsonPropertyName("subdivision")]
    public List<string>? Subdivision { get; set; }

    [JsonPropertyName("subunit")]
    public List<string>? Subunit { get; set; }
}
