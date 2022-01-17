using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.ServerGroups
{

    internal class NameAvailabilityRequestModel
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        [Required]
        public CheckNameAvailabilityResourceTypeConstant Type { get; set; }
    }
}
