using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.Restorables;


internal class RestorableMongodbCollectionPropertiesResourceModel
{
    [JsonPropertyName("eventTimestamp")]
    public string? EventTimestamp { get; set; }

    [JsonPropertyName("operationType")]
    public OperationTypeConstant? OperationType { get; set; }

    [JsonPropertyName("ownerId")]
    public string? OwnerId { get; set; }

    [JsonPropertyName("ownerResourceId")]
    public string? OwnerResourceId { get; set; }

    [JsonPropertyName("_rid")]
    public string? Rid { get; set; }
}
