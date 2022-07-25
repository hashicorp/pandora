using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SignalR.v2022_02_01.SignalR;


internal class CustomCertificatePropertiesModel
{
    [JsonPropertyName("keyVaultBaseUri")]
    [Required]
    public string KeyVaultBaseUri { get; set; }

    [JsonPropertyName("keyVaultSecretName")]
    [Required]
    public string KeyVaultSecretName { get; set; }

    [JsonPropertyName("keyVaultSecretVersion")]
    public string? KeyVaultSecretVersion { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
