using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;

[ValueForType("KeyVaultCertificate")]
internal class KeyVaultCertificatePropertiesModel : CertificatePropertiesModel
{
    [JsonPropertyName("certVersion")]
    public string? CertVersion { get; set; }

    [JsonPropertyName("excludePrivateKey")]
    public bool? ExcludePrivateKey { get; set; }

    [JsonPropertyName("keyVaultCertName")]
    [Required]
    public string KeyVaultCertName { get; set; }

    [JsonPropertyName("vaultUri")]
    [Required]
    public string VaultUri { get; set; }
}
