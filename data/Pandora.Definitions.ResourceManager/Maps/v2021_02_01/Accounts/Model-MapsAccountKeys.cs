using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{

    internal class MapsAccountKeys
    {
        [JsonPropertyName("primaryKey")]
        public string? PrimaryKey { get; set; }

        [JsonPropertyName("primaryKeyLastUpdated")]
        public string? PrimaryKeyLastUpdated { get; set; }

        [JsonPropertyName("secondaryKey")]
        public string? SecondaryKey { get; set; }

        [JsonPropertyName("secondaryKeyLastUpdated")]
        public string? SecondaryKeyLastUpdated { get; set; }
    }
}
