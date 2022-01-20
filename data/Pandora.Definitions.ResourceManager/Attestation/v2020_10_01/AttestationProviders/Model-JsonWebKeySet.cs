using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders;


internal class JsonWebKeySetModel
{
    [JsonPropertyName("keys")]
    public List<JsonWebKeyModel>? Keys { get; set; }
}
