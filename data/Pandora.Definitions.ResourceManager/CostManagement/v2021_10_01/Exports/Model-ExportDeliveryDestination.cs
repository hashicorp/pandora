using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Exports;


internal class ExportDeliveryDestinationModel
{
    [JsonPropertyName("container")]
    [Required]
    public string Container { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("rootFolderPath")]
    public string? RootFolderPath { get; set; }

    [JsonPropertyName("sasToken")]
    public string? SasToken { get; set; }

    [JsonPropertyName("storageAccount")]
    public string? StorageAccount { get; set; }
}
