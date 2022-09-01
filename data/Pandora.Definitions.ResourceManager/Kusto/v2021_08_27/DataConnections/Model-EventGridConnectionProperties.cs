using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.DataConnections;


internal class EventGridConnectionPropertiesModel
{
    [JsonPropertyName("blobStorageEventType")]
    public BlobStorageEventTypeConstant? BlobStorageEventType { get; set; }

    [JsonPropertyName("consumerGroup")]
    [Required]
    public string ConsumerGroup { get; set; }

    [JsonPropertyName("dataFormat")]
    public EventGridDataFormatConstant? DataFormat { get; set; }

    [JsonPropertyName("eventHubResourceId")]
    [Required]
    public string EventHubResourceId { get; set; }

    [JsonPropertyName("ignoreFirstRecord")]
    public bool? IgnoreFirstRecord { get; set; }

    [JsonPropertyName("mappingRuleName")]
    public string? MappingRuleName { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("storageAccountResourceId")]
    [Required]
    public string StorageAccountResourceId { get; set; }

    [JsonPropertyName("tableName")]
    public string? TableName { get; set; }
}
