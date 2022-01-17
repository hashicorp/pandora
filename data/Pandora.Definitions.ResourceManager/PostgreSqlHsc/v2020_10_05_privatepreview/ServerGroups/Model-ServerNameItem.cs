using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.ServerGroups
{

    internal class ServerNameItemModel
    {
        [JsonPropertyName("fullyQualifiedDomainName")]
        public string? FullyQualifiedDomainName { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
