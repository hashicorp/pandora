using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ConnectionMonitors;


internal class ConnectionMonitorParametersModel
{
    [JsonPropertyName("autoStart")]
    public bool? AutoStart { get; set; }

    [JsonPropertyName("destination")]
    public ConnectionMonitorDestinationModel? Destination { get; set; }

    [JsonPropertyName("endpoints")]
    public List<ConnectionMonitorEndpointModel>? Endpoints { get; set; }

    [JsonPropertyName("monitoringIntervalInSeconds")]
    public int? MonitoringIntervalInSeconds { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("outputs")]
    public List<ConnectionMonitorOutputModel>? Outputs { get; set; }

    [JsonPropertyName("source")]
    public ConnectionMonitorSourceModel? Source { get; set; }

    [JsonPropertyName("testConfigurations")]
    public List<ConnectionMonitorTestConfigurationModel>? TestConfigurations { get; set; }

    [JsonPropertyName("testGroups")]
    public List<ConnectionMonitorTestGroupModel>? TestGroups { get; set; }
}
