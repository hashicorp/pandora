using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.EventHubs;


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
