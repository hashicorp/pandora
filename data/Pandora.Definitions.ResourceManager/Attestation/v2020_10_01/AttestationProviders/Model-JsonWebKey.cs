using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders;


internal class JsonWebKeyModel
{
    [JsonPropertyName("alg")]
    public string? Alg { get; set; }

    [JsonPropertyName("crv")]
    public string? Crv { get; set; }

    [JsonPropertyName("d")]
    public string? D { get; set; }

    [JsonPropertyName("dp")]
    public string? Dp { get; set; }

    [JsonPropertyName("dq")]
    public string? Dq { get; set; }

    [JsonPropertyName("e")]
    public string? E { get; set; }

    [JsonPropertyName("k")]
    public string? K { get; set; }

    [JsonPropertyName("kid")]
    public string? Kid { get; set; }

    [JsonPropertyName("kty")]
    [Required]
    public string Kty { get; set; }

    [JsonPropertyName("n")]
    public string? N { get; set; }

    [JsonPropertyName("p")]
    public string? P { get; set; }

    [JsonPropertyName("q")]
    public string? Q { get; set; }

    [JsonPropertyName("qi")]
    public string? Qi { get; set; }

    [JsonPropertyName("use")]
    public string? Use { get; set; }

    [JsonPropertyName("x")]
    public string? X { get; set; }

    [JsonPropertyName("x5c")]
    public List<string>? XFivec { get; set; }

    [JsonPropertyName("y")]
    public string? Y { get; set; }
}
