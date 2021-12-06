using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.Databases
{

    internal class PersistenceModel
    {
        [JsonPropertyName("aofEnabled")]
        public bool? AofEnabled { get; set; }

        [JsonPropertyName("aofFrequency")]
        public AofFrequencyConstant? AofFrequency { get; set; }

        [JsonPropertyName("rdbEnabled")]
        public bool? RdbEnabled { get; set; }

        [JsonPropertyName("rdbFrequency")]
        public RdbFrequencyConstant? RdbFrequency { get; set; }
    }
}
