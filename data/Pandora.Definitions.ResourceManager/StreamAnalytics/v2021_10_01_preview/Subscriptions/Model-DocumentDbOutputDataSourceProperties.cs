using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;


internal class DocumentDbOutputDataSourcePropertiesModel
{
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("accountKey")]
    public string? AccountKey { get; set; }

    [JsonPropertyName("authenticationMode")]
    public AuthenticationModeConstant? AuthenticationMode { get; set; }

    [JsonPropertyName("collectionNamePattern")]
    public string? CollectionNamePattern { get; set; }

    [JsonPropertyName("database")]
    public string? Database { get; set; }

    [JsonPropertyName("documentId")]
    public string? DocumentId { get; set; }

    [JsonPropertyName("partitionKey")]
    public string? PartitionKey { get; set; }
}
