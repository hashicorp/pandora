using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.Keys;


internal class KeyPropertiesModel
{
    [JsonPropertyName("attributes")]
    public KeyAttributesModel? Attributes { get; set; }

    [JsonPropertyName("curveName")]
    public JsonWebKeyCurveNameConstant? CurveName { get; set; }

    [JsonPropertyName("keyOps")]
    public List<JsonWebKeyOperationConstant>? KeyOps { get; set; }

    [JsonPropertyName("keySize")]
    public int? KeySize { get; set; }

    [JsonPropertyName("keyUri")]
    public string? KeyUri { get; set; }

    [JsonPropertyName("keyUriWithVersion")]
    public string? KeyUriWithVersion { get; set; }

    [JsonPropertyName("kty")]
    public JsonWebKeyTypeConstant? Kty { get; set; }

    [JsonPropertyName("release_policy")]
    public KeyReleasePolicyModel? ReleasePolicy { get; set; }

    [JsonPropertyName("rotationPolicy")]
    public RotationPolicyModel? RotationPolicy { get; set; }
}
