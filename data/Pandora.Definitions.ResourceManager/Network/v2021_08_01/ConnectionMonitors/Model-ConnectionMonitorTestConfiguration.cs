using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ConnectionMonitors;


internal class ConnectionMonitorTestConfigurationModel
{
    [JsonPropertyName("httpConfiguration")]
    public ConnectionMonitorHttpConfigurationModel? HttpConfiguration { get; set; }

    [JsonPropertyName("icmpConfiguration")]
    public ConnectionMonitorIcmpConfigurationModel? IcmpConfiguration { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("preferredIPVersion")]
    public PreferredIPVersionConstant? PreferredIPVersion { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public ConnectionMonitorTestConfigurationProtocolConstant Protocol { get; set; }

    [JsonPropertyName("successThreshold")]
    public ConnectionMonitorSuccessThresholdModel? SuccessThreshold { get; set; }

    [JsonPropertyName("tcpConfiguration")]
    public ConnectionMonitorTcpConfigurationModel? TcpConfiguration { get; set; }

    [JsonPropertyName("testFrequencySec")]
    public int? TestFrequencySec { get; set; }
}
