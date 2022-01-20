using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Configurations;


internal class ServerGroupConfigurationPropertiesModel
{
    [JsonPropertyName("allowedValues")]
    public string? AllowedValues { get; set; }

    [JsonPropertyName("dataType")]
    public ConfigurationDataTypeConstant? DataType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("serverRoleGroupConfigurations")]
    [Required]
    public List<ServerRoleGroupConfigurationModel> ServerRoleGroupConfigurations { get; set; }
}
