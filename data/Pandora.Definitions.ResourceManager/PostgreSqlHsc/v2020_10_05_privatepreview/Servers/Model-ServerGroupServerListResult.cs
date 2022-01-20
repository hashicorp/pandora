using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Servers;


internal class ServerGroupServerListResultModel
{
    [JsonPropertyName("value")]
    public List<ServerGroupServerModel>? Value { get; set; }
}
