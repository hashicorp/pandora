using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;


internal class DatabasePropertiesGeoReplicationModel
{
    [JsonPropertyName("groupNickname")]
    public string? GroupNickname { get; set; }

    [JsonPropertyName("linkedDatabases")]
    public List<LinkedDatabaseModel>? LinkedDatabases { get; set; }
}
