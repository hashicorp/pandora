using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubs;


internal class DestinationPropertiesModel
{
    [JsonPropertyName("archiveNameFormat")]
    public string? ArchiveNameFormat { get; set; }

    [JsonPropertyName("blobContainer")]
    public string? BlobContainer { get; set; }

    [JsonPropertyName("storageAccountResourceId")]
    public string? StorageAccountResourceId { get; set; }
}
