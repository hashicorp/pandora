using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets
{

    internal class ARecordModel
    {
        [JsonPropertyName("ipv4Address")]
        public string? Ipv4Address { get; set; }
    }
}
