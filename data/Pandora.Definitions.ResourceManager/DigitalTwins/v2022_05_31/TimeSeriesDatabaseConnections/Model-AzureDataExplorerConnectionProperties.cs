using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2022_05_31.TimeSeriesDatabaseConnections;

[ValueForType("AzureDataExplorer")]
internal class AzureDataExplorerConnectionPropertiesModel : TimeSeriesDatabaseConnectionPropertiesModel
{
    [JsonPropertyName("adxDatabaseName")]
    [Required]
    public string AdxDatabaseName { get; set; }

    [JsonPropertyName("adxEndpointUri")]
    [Required]
    public string AdxEndpointUri { get; set; }

    [JsonPropertyName("adxResourceId")]
    [Required]
    public string AdxResourceId { get; set; }

    [JsonPropertyName("adxTableName")]
    public string? AdxTableName { get; set; }

    [JsonPropertyName("eventHubConsumerGroup")]
    public string? EventHubConsumerGroup { get; set; }

    [JsonPropertyName("eventHubEndpointUri")]
    [Required]
    public string EventHubEndpointUri { get; set; }

    [JsonPropertyName("eventHubEntityPath")]
    [Required]
    public string EventHubEntityPath { get; set; }

    [JsonPropertyName("eventHubNamespaceResourceId")]
    [Required]
    public string EventHubNamespaceResourceId { get; set; }
}
