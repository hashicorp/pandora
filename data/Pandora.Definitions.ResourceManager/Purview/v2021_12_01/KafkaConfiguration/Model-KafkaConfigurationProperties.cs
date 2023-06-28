using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Purview.v2021_12_01.KafkaConfiguration;


internal class KafkaConfigurationPropertiesModel
{
    [JsonPropertyName("consumerGroup")]
    public string? ConsumerGroup { get; set; }

    [JsonPropertyName("credentials")]
    public CredentialsModel? Credentials { get; set; }

    [JsonPropertyName("eventHubPartitionId")]
    public string? EventHubPartitionId { get; set; }

    [JsonPropertyName("eventHubResourceId")]
    public string? EventHubResourceId { get; set; }

    [JsonPropertyName("eventHubType")]
    public EventHubTypeConstant? EventHubType { get; set; }

    [JsonPropertyName("eventStreamingState")]
    public EventStreamingStateConstant? EventStreamingState { get; set; }

    [JsonPropertyName("eventStreamingType")]
    public EventStreamingTypeConstant? EventStreamingType { get; set; }
}
