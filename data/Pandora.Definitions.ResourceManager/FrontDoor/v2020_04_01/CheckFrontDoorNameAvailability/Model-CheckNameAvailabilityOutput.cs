using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.CheckFrontDoorNameAvailability
{

    internal class CheckNameAvailabilityOutputModel
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("nameAvailability")]
        public AvailabilityConstant? NameAvailability { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }
}
