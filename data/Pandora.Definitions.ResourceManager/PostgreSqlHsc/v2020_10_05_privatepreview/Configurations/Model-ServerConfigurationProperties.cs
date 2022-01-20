using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Configurations;


internal class ServerConfigurationPropertiesModel
{
    [JsonPropertyName("allowedValues")]
    public string? AllowedValues { get; set; }

    [JsonPropertyName("dataType")]
    public ConfigurationDataTypeConstant? DataType { get; set; }

    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public string Value { get; set; }
}
