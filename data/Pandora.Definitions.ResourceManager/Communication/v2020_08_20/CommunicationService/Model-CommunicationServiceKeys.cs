using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService;


internal class CommunicationServiceKeysModel
{
    [JsonPropertyName("primaryConnectionString")]
    public string? PrimaryConnectionString { get; set; }

    [JsonPropertyName("primaryKey")]
    public string? PrimaryKey { get; set; }

    [JsonPropertyName("secondaryConnectionString")]
    public string? SecondaryConnectionString { get; set; }

    [JsonPropertyName("secondaryKey")]
    public string? SecondaryKey { get; set; }
}
