using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Regions;


internal class MessagingRegionsPropertiesModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("fullName")]
    public string? FullName { get; set; }
}
