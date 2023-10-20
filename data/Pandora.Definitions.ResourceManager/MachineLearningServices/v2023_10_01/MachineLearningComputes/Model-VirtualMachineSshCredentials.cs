using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.MachineLearningComputes;


internal class VirtualMachineSshCredentialsModel
{
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("privateKeyData")]
    public string? PrivateKeyData { get; set; }

    [JsonPropertyName("publicKeyData")]
    public string? PublicKeyData { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
