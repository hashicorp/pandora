using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;


internal class AccessKeysModel
{
    [JsonPropertyName("primaryKey")]
    public string? PrimaryKey { get; set; }

    [JsonPropertyName("secondaryKey")]
    public string? SecondaryKey { get; set; }
}
