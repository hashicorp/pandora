using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.Vaults;


internal class PermissionsModel
{
    [JsonPropertyName("certificates")]
    public List<CertificatePermissionsConstant>? Certificates { get; set; }

    [JsonPropertyName("keys")]
    public List<KeyPermissionsConstant>? Keys { get; set; }

    [JsonPropertyName("secrets")]
    public List<SecretPermissionsConstant>? Secrets { get; set; }

    [JsonPropertyName("storage")]
    public List<StoragePermissionsConstant>? Storage { get; set; }
}
