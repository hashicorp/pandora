using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;


internal class DeletedShareModel
{
    [JsonPropertyName("deletedShareName")]
    [Required]
    public string DeletedShareName { get; set; }

    [JsonPropertyName("deletedShareVersion")]
    [Required]
    public string DeletedShareVersion { get; set; }
}
