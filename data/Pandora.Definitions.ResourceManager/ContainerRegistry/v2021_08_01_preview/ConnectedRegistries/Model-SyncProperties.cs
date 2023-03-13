using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.ConnectedRegistries;


internal class SyncPropertiesModel
{
    [JsonPropertyName("gatewayEndpoint")]
    public string? GatewayEndpoint { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSyncTime")]
    public DateTime? LastSyncTime { get; set; }

    [JsonPropertyName("messageTtl")]
    [Required]
    public string MessageTtl { get; set; }

    [JsonPropertyName("schedule")]
    public string? Schedule { get; set; }

    [JsonPropertyName("syncWindow")]
    public string? SyncWindow { get; set; }

    [JsonPropertyName("tokenId")]
    [Required]
    public string TokenId { get; set; }
}
