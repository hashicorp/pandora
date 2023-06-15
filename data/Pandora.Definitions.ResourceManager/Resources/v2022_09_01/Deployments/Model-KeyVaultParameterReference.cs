using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Deployments;


internal class KeyVaultParameterReferenceModel
{
    [JsonPropertyName("keyVault")]
    [Required]
    public KeyVaultReferenceModel KeyVault { get; set; }

    [JsonPropertyName("secretName")]
    [Required]
    public string SecretName { get; set; }

    [JsonPropertyName("secretVersion")]
    public string? SecretVersion { get; set; }
}
