using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{

    internal class MapsKeySpecificationModel
    {
        [JsonPropertyName("keyType")]
        [Required]
        public KeyTypeConstant KeyType { get; set; }
    }
}
