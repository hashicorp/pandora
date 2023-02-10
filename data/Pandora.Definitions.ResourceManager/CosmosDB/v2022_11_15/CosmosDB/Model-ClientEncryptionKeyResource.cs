using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.CosmosDB;


internal class ClientEncryptionKeyResourceModel
{
    [JsonPropertyName("encryptionAlgorithm")]
    public string? EncryptionAlgorithm { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("keyWrapMetadata")]
    public KeyWrapMetadataModel? KeyWrapMetadata { get; set; }

    [JsonPropertyName("wrappedDataEncryptionKey")]
    public string? WrappedDataEncryptionKey { get; set; }
}
