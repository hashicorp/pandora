using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Webhooks;


internal class WebhookCreateParametersModel
{
    [JsonPropertyName("location")]
    [Required]
    public CustomTypes.Location Location { get; set; }

    [JsonPropertyName("properties")]
    public WebhookPropertiesCreateParametersModel? Properties { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
