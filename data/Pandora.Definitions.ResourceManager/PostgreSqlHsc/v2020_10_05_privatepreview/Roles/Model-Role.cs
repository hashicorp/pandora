using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Roles;


internal class RoleModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("properties")]
    public RolePropertiesModel? Properties { get; set; }

    [JsonPropertyName("systemData")]
    public SystemDataModel? SystemData { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
