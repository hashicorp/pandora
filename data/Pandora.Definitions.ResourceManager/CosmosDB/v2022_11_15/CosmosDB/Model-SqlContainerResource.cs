using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.CosmosDB;


internal class SqlContainerResourceModel
{
    [JsonPropertyName("analyticalStorageTtl")]
    public int? AnalyticalStorageTtl { get; set; }

    [JsonPropertyName("clientEncryptionPolicy")]
    public ClientEncryptionPolicyModel? ClientEncryptionPolicy { get; set; }

    [JsonPropertyName("conflictResolutionPolicy")]
    public ConflictResolutionPolicyModel? ConflictResolutionPolicy { get; set; }

    [JsonPropertyName("defaultTtl")]
    public int? DefaultTtl { get; set; }

    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [JsonPropertyName("indexingPolicy")]
    public IndexingPolicyModel? IndexingPolicy { get; set; }

    [JsonPropertyName("partitionKey")]
    public ContainerPartitionKeyModel? PartitionKey { get; set; }

    [JsonPropertyName("uniqueKeyPolicy")]
    public UniqueKeyPolicyModel? UniqueKeyPolicy { get; set; }
}
