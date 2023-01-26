using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ConnectionMonitors;


internal class ConnectionMonitorResultPropertiesModel
{
    [JsonPropertyName("autoStart")]
    public bool? AutoStart { get; set; }

    [JsonPropertyName("connectionMonitorType")]
    public ConnectionMonitorTypeConstant? ConnectionMonitorType { get; set; }

    [JsonPropertyName("destination")]
    public ConnectionMonitorDestinationModel? Destination { get; set; }

    [JsonPropertyName("endpoints")]
    public List<ConnectionMonitorEndpointModel>? Endpoints { get; set; }

    [JsonPropertyName("monitoringIntervalInSeconds")]
    public int? MonitoringIntervalInSeconds { get; set; }

    [JsonPropertyName("monitoringStatus")]
    public string? MonitoringStatus { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("outputs")]
    public List<ConnectionMonitorOutputModel>? Outputs { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("source")]
    public ConnectionMonitorSourceModel? Source { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("testConfigurations")]
    public List<ConnectionMonitorTestConfigurationModel>? TestConfigurations { get; set; }

    [JsonPropertyName("testGroups")]
    public List<ConnectionMonitorTestGroupModel>? TestGroups { get; set; }
}
