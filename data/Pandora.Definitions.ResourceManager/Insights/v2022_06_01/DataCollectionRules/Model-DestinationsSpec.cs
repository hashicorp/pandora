using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;


internal class DestinationsSpecModel
{
    [JsonPropertyName("azureMonitorMetrics")]
    public AzureMonitorMetricsDestinationModel? AzureMonitorMetrics { get; set; }

    [JsonPropertyName("eventHubs")]
    public List<EventHubDestinationModel>? EventHubs { get; set; }

    [JsonPropertyName("eventHubsDirect")]
    public List<EventHubDirectDestinationModel>? EventHubsDirect { get; set; }

    [JsonPropertyName("logAnalytics")]
    public List<LogAnalyticsDestinationModel>? LogAnalytics { get; set; }

    [JsonPropertyName("monitoringAccounts")]
    public List<MonitoringAccountDestinationModel>? MonitoringAccounts { get; set; }

    [JsonPropertyName("storageAccounts")]
    public List<StorageBlobDestinationModel>? StorageAccounts { get; set; }

    [JsonPropertyName("storageBlobsDirect")]
    public List<StorageBlobDestinationModel>? StorageBlobsDirect { get; set; }

    [JsonPropertyName("storageTablesDirect")]
    public List<StorageTableDestinationModel>? StorageTablesDirect { get; set; }
}
