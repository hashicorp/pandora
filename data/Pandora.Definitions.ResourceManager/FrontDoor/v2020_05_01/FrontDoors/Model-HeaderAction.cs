using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors
{

    internal class HeaderActionModel
    {
        [JsonPropertyName("headerActionType")]
        [Required]
        public HeaderActionTypeConstant HeaderActionType { get; set; }

        [JsonPropertyName("headerName")]
        [Required]
        public string HeaderName { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
