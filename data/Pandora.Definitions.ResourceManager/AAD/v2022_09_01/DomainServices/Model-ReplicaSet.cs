using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2022_09_01.DomainServices;


internal class ReplicaSetModel
{
    [JsonPropertyName("domainControllerIpAddress")]
    public List<string>? DomainControllerIPAddress { get; set; }

    [JsonPropertyName("externalAccessIpAddress")]
    public string? ExternalAccessIPAddress { get; set; }

    [JsonPropertyName("healthAlerts")]
    public List<HealthAlertModel>? HealthAlerts { get; set; }

    [JsonPropertyName("healthLastEvaluated")]
    public string? HealthLastEvaluated { get; set; }

    [JsonPropertyName("healthMonitors")]
    public List<HealthMonitorModel>? HealthMonitors { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("replicaSetId")]
    public string? ReplicaSetId { get; set; }

    [JsonPropertyName("serviceStatus")]
    public string? ServiceStatus { get; set; }

    [JsonPropertyName("subnetId")]
    public string? SubnetId { get; set; }

    [JsonPropertyName("vnetSiteId")]
    public string? VnetSiteId { get; set; }
}
