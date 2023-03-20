using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.Monitors;


internal class MonitorPropertiesModel
{
    [JsonPropertyName("appLocation")]
    public string? AppLocation { get; set; }

    [JsonPropertyName("errors")]
    public ErrorModel? Errors { get; set; }

    [JsonPropertyName("logAnalyticsWorkspaceArmId")]
    public string? LogAnalyticsWorkspaceArmId { get; set; }

    [JsonPropertyName("managedResourceGroupConfiguration")]
    public ManagedRGConfigurationModel? ManagedResourceGroupConfiguration { get; set; }

    [JsonPropertyName("monitorSubnet")]
    public string? MonitorSubnet { get; set; }

    [JsonPropertyName("msiArmId")]
    public string? MsiArmId { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkloadMonitorProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("routingPreference")]
    public RoutingPreferenceConstant? RoutingPreference { get; set; }

    [JsonPropertyName("storageAccountArmId")]
    public string? StorageAccountArmId { get; set; }

    [JsonPropertyName("zoneRedundancyPreference")]
    public string? ZoneRedundancyPreference { get; set; }
}
