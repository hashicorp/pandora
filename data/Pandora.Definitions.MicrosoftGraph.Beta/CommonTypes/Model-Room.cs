// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RoomModel
{
    [JsonPropertyName("address")]
    public PhysicalAddressModel? Address { get; set; }

    [JsonPropertyName("audioDeviceName")]
    public string? AudioDeviceName { get; set; }

    [JsonPropertyName("bookingType")]
    public BookingTypeConstant? BookingType { get; set; }

    [JsonPropertyName("building")]
    public string? Building { get; set; }

    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    [JsonPropertyName("displayDeviceName")]
    public string? DisplayDeviceName { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("floorLabel")]
    public string? FloorLabel { get; set; }

    [JsonPropertyName("floorNumber")]
    public int? FloorNumber { get; set; }

    [JsonPropertyName("geoCoordinates")]
    public OutlookGeoCoordinatesModel? GeoCoordinates { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isWheelChairAccessible")]
    public bool? IsWheelChairAccessible { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("videoDeviceName")]
    public string? VideoDeviceName { get; set; }
}
