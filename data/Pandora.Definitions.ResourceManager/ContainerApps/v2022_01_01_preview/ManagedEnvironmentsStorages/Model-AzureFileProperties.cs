using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironmentsStorages;


internal class AzureFilePropertiesModel
{
    [JsonPropertyName("accessMode")]
    public AccessModeConstant? AccessMode { get; set; }

    [JsonPropertyName("accountKey")]
    public string? AccountKey { get; set; }

    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("shareName")]
    public string? ShareName { get; set; }
}
