// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ManagedDeviceOverviewModel
{
    [JsonPropertyName("deviceExchangeAccessStateSummary")]
    public DeviceExchangeAccessStateSummaryModel? DeviceExchangeAccessStateSummary { get; set; }

    [JsonPropertyName("deviceOperatingSystemSummary")]
    public DeviceOperatingSystemSummaryModel? DeviceOperatingSystemSummary { get; set; }

    [JsonPropertyName("dualEnrolledDeviceCount")]
    public int? DualEnrolledDeviceCount { get; set; }

    [JsonPropertyName("enrolledDeviceCount")]
    public int? EnrolledDeviceCount { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("mdmEnrolledCount")]
    public int? MdmEnrolledCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
