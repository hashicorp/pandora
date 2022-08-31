using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.EventHubs;


internal class DestinationPropertiesModel
{
    [JsonPropertyName("archiveNameFormat")]
    public string? ArchiveNameFormat { get; set; }

    [JsonPropertyName("blobContainer")]
    public string? BlobContainer { get; set; }

    [JsonPropertyName("dataLakeAccountName")]
    public string? DataLakeAccountName { get; set; }

    [JsonPropertyName("dataLakeFolderPath")]
    public string? DataLakeFolderPath { get; set; }

    [JsonPropertyName("dataLakeSubscriptionId")]
    public string? DataLakeSubscriptionId { get; set; }

    [JsonPropertyName("storageAccountResourceId")]
    public string? StorageAccountResourceId { get; set; }
}
