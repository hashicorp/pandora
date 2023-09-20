// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CallRecordsNetworkInfoModel
{
    [JsonPropertyName("basicServiceSetIdentifier")]
    public string? BasicServiceSetIdentifier { get; set; }

    [JsonPropertyName("connectionType")]
    public CallRecordsNetworkInfoConnectionTypeConstant? ConnectionType { get; set; }

    [JsonPropertyName("dnsSuffix")]
    public string? DnsSuffix { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("linkSpeed")]
    public int? LinkSpeed { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("networkTransportProtocol")]
    public CallRecordsNetworkInfoNetworkTransportProtocolConstant? NetworkTransportProtocol { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("reflexiveIPAddress")]
    public string? ReflexiveIPAddress { get; set; }

    [JsonPropertyName("relayIPAddress")]
    public string? RelayIPAddress { get; set; }

    [JsonPropertyName("relayPort")]
    public int? RelayPort { get; set; }

    [JsonPropertyName("subnet")]
    public string? Subnet { get; set; }

    [JsonPropertyName("traceRouteHops")]
    public List<CallRecordsTraceRouteHopModel>? TraceRouteHops { get; set; }

    [JsonPropertyName("wifiBand")]
    public CallRecordsNetworkInfoWifiBandConstant? WifiBand { get; set; }

    [JsonPropertyName("wifiBatteryCharge")]
    public int? WifiBatteryCharge { get; set; }

    [JsonPropertyName("wifiChannel")]
    public int? WifiChannel { get; set; }

    [JsonPropertyName("wifiMicrosoftDriver")]
    public string? WifiMicrosoftDriver { get; set; }

    [JsonPropertyName("wifiMicrosoftDriverVersion")]
    public string? WifiMicrosoftDriverVersion { get; set; }

    [JsonPropertyName("wifiRadioType")]
    public CallRecordsNetworkInfoWifiRadioTypeConstant? WifiRadioType { get; set; }

    [JsonPropertyName("wifiSignalStrength")]
    public int? WifiSignalStrength { get; set; }

    [JsonPropertyName("wifiVendorDriver")]
    public string? WifiVendorDriver { get; set; }

    [JsonPropertyName("wifiVendorDriverVersion")]
    public string? WifiVendorDriverVersion { get; set; }
}
