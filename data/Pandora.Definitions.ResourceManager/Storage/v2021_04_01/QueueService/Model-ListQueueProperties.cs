using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.QueueService;


internal class ListQueuePropertiesModel
{
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }
}
