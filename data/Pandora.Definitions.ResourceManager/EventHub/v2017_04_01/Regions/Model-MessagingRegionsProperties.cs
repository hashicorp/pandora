using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Regions;


internal class MessagingRegionsPropertiesModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("fullName")]
    public string? FullName { get; set; }
}
