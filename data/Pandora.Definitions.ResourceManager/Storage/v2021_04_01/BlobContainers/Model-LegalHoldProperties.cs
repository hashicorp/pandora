using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;


internal class LegalHoldPropertiesModel
{
    [JsonPropertyName("hasLegalHold")]
    public bool? HasLegalHold { get; set; }

    [JsonPropertyName("tags")]
    public List<TagPropertyModel>? Tags { get; set; }
}
