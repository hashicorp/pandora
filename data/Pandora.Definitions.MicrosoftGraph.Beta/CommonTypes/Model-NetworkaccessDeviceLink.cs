// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessDeviceLinkModel
{
    [JsonPropertyName("bandwidthCapacityInMbps")]
    public NetworkaccessDeviceLinkBandwidthCapacityInMbpsConstant? BandwidthCapacityInMbps { get; set; }

    [JsonPropertyName("bgpConfiguration")]
    public BgpConfigurationModel? BgpConfiguration { get; set; }

    [JsonPropertyName("deviceVendor")]
    public NetworkaccessDeviceLinkDeviceVendorConstant? DeviceVendor { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("redundancyConfiguration")]
    public NetworkaccessRedundancyConfigurationModel? RedundancyConfiguration { get; set; }

    [JsonPropertyName("tunnelConfiguration")]
    public TunnelConfigurationModel? TunnelConfiguration { get; set; }
}
