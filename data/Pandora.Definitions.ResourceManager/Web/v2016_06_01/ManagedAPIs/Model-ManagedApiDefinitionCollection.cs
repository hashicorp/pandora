using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;


internal class ManagedApiDefinitionCollectionModel
{
    [JsonPropertyName("value")]
    public List<ManagedApiDefinitionModel>? Value { get; set; }
}
