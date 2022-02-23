using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class BlobRestoreRangeModel
{
    [JsonPropertyName("endRange")]
    [Required]
    public string EndRange { get; set; }

    [JsonPropertyName("startRange")]
    [Required]
    public string StartRange { get; set; }
}
