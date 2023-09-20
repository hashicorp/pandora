// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AppleVpnAlwaysOnConfigurationModel
{
    [JsonPropertyName("airPrintExceptionAction")]
    public AppleVpnAlwaysOnConfigurationAirPrintExceptionActionConstant? AirPrintExceptionAction { get; set; }

    [JsonPropertyName("allowAllCaptiveNetworkPlugins")]
    public bool? AllowAllCaptiveNetworkPlugins { get; set; }

    [JsonPropertyName("allowCaptiveWebSheet")]
    public bool? AllowCaptiveWebSheet { get; set; }

    [JsonPropertyName("allowedCaptiveNetworkPlugins")]
    public SpecifiedCaptiveNetworkPluginsModel? AllowedCaptiveNetworkPlugins { get; set; }

    [JsonPropertyName("cellularExceptionAction")]
    public AppleVpnAlwaysOnConfigurationCellularExceptionActionConstant? CellularExceptionAction { get; set; }

    [JsonPropertyName("natKeepAliveIntervalInSeconds")]
    public int? NatKeepAliveIntervalInSeconds { get; set; }

    [JsonPropertyName("natKeepAliveOffloadEnable")]
    public bool? NatKeepAliveOffloadEnable { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tunnelConfiguration")]
    public AppleVpnAlwaysOnConfigurationTunnelConfigurationConstant? TunnelConfiguration { get; set; }

    [JsonPropertyName("userToggleEnabled")]
    public bool? UserToggleEnabled { get; set; }

    [JsonPropertyName("voicemailExceptionAction")]
    public AppleVpnAlwaysOnConfigurationVoicemailExceptionActionConstant? VoicemailExceptionAction { get; set; }
}
