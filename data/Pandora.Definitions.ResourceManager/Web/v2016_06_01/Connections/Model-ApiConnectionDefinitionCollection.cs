using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;


internal class ApiConnectionDefinitionCollectionModel
{
    [JsonPropertyName("value")]
    public List<ApiConnectionDefinitionModel>? Value { get; set; }
}
