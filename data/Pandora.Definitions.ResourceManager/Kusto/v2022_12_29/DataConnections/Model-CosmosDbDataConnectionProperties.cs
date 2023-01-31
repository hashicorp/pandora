using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_12_29.DataConnections;


internal class CosmosDbDataConnectionPropertiesModel
{
    [JsonPropertyName("cosmosDbAccountResourceId")]
    [Required]
    public string CosmosDbAccountResourceId { get; set; }

    [JsonPropertyName("cosmosDbContainer")]
    [Required]
    public string CosmosDbContainer { get; set; }

    [JsonPropertyName("cosmosDbDatabase")]
    [Required]
    public string CosmosDbDatabase { get; set; }

    [JsonPropertyName("managedIdentityObjectId")]
    public string? ManagedIdentityObjectId { get; set; }

    [JsonPropertyName("managedIdentityResourceId")]
    [Required]
    public string ManagedIdentityResourceId { get; set; }

    [JsonPropertyName("mappingRuleName")]
    public string? MappingRuleName { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("retrievalStartDate")]
    public DateTime? RetrievalStartDate { get; set; }

    [JsonPropertyName("tableName")]
    [Required]
    public string TableName { get; set; }
}
