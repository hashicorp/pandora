using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.VMIngestionDetails;


internal class VMIngestionDetailsResponseModel
{
    [JsonPropertyName("cloudId")]
    public string? CloudId { get; set; }

    [JsonPropertyName("ingestionKey")]
    public string? IngestionKey { get; set; }
}
