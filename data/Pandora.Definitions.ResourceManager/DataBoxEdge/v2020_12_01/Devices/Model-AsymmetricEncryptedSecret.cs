using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Devices;


internal class AsymmetricEncryptedSecretModel
{
    [JsonPropertyName("encryptionAlgorithm")]
    [Required]
    public EncryptionAlgorithmConstant EncryptionAlgorithm { get; set; }

    [JsonPropertyName("encryptionCertThumbprint")]
    public string? EncryptionCertThumbprint { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public string Value { get; set; }
}
