using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;


internal class ValidateCustomDomainOutputModel
{
    [JsonPropertyName("customDomainValidated")]
    public bool? CustomDomainValidated { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}
