using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.SshPublicKeys;


internal class SshPublicKeyGenerateKeyPairResultModel
{
    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [JsonPropertyName("privateKey")]
    [Required]
    public string PrivateKey { get; set; }

    [JsonPropertyName("publicKey")]
    [Required]
    public string PublicKey { get; set; }
}
