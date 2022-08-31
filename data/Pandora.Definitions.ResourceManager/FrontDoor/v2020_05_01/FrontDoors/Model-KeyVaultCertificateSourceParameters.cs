using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;


internal class KeyVaultCertificateSourceParametersModel
{
    [JsonPropertyName("secretName")]
    public string? SecretName { get; set; }

    [JsonPropertyName("secretVersion")]
    public string? SecretVersion { get; set; }

    [JsonPropertyName("vault")]
    public KeyVaultCertificateSourceParametersVaultModel? Vault { get; set; }
}
