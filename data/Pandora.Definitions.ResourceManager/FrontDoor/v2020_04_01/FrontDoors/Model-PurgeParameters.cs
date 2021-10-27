using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors
{

    internal class PurgeParametersModel
    {
        [JsonPropertyName("contentPaths")]
        [Required]
        public List<string> ContentPaths { get; set; }
    }
}
