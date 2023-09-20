// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceEnrollmentPlatformRestrictionModel
{
    [JsonPropertyName("blockedManufacturers")]
    public List<string>? BlockedManufacturers { get; set; }

    [JsonPropertyName("blockedSkus")]
    public List<string>? BlockedSkus { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("osMaximumVersion")]
    public string? OsMaximumVersion { get; set; }

    [JsonPropertyName("osMinimumVersion")]
    public string? OsMinimumVersion { get; set; }

    [JsonPropertyName("personalDeviceEnrollmentBlocked")]
    public bool? PersonalDeviceEnrollmentBlocked { get; set; }

    [JsonPropertyName("platformBlocked")]
    public bool? PlatformBlocked { get; set; }
}
