using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.DataConnections;


internal class IotHubConnectionPropertiesModel
{
    [JsonPropertyName("consumerGroup")]
    [Required]
    public string ConsumerGroup { get; set; }

    [JsonPropertyName("dataFormat")]
    public IotHubDataFormatConstant? DataFormat { get; set; }

    [JsonPropertyName("databaseRouting")]
    public DatabaseRoutingConstant? DatabaseRouting { get; set; }

    [JsonPropertyName("eventSystemProperties")]
    public List<string>? EventSystemProperties { get; set; }

    [JsonPropertyName("iotHubResourceId")]
    [Required]
    public string IotHubResourceId { get; set; }

    [JsonPropertyName("mappingRuleName")]
    public string? MappingRuleName { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("retrievalStartDate")]
    public DateTime? RetrievalStartDate { get; set; }

    [JsonPropertyName("sharedAccessPolicyName")]
    [Required]
    public string SharedAccessPolicyName { get; set; }

    [JsonPropertyName("tableName")]
    public string? TableName { get; set; }
}
