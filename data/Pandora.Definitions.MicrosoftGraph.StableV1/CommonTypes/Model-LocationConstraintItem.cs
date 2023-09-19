// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class LocationConstraintItemModel
{
    [JsonPropertyName("address")]
    public PhysicalAddressModel? Address { get; set; }

    [JsonPropertyName("coordinates")]
    public OutlookGeoCoordinatesModel? Coordinates { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("locationEmailAddress")]
    public string? LocationEmailAddress { get; set; }

    [JsonPropertyName("locationType")]
    public LocationConstraintItemLocationTypeConstant? LocationType { get; set; }

    [JsonPropertyName("locationUri")]
    public string? LocationUri { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resolveAvailability")]
    public bool? ResolveAvailability { get; set; }

    [JsonPropertyName("uniqueId")]
    public string? UniqueId { get; set; }

    [JsonPropertyName("uniqueIdType")]
    public LocationConstraintItemUniqueIdTypeConstant? UniqueIdType { get; set; }
}
