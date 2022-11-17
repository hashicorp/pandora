using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PrivateClouds;


internal class EncryptionKeyVaultPropertiesModel
{
    [JsonPropertyName("autoDetectedKeyVersion")]
    public string? AutoDetectedKeyVersion { get; set; }

    [JsonPropertyName("keyName")]
    public string? KeyName { get; set; }

    [JsonPropertyName("keyState")]
    public EncryptionKeyStatusConstant? KeyState { get; set; }

    [JsonPropertyName("keyVaultUrl")]
    public string? KeyVaultUrl { get; set; }

    [JsonPropertyName("keyVersion")]
    public string? KeyVersion { get; set; }

    [JsonPropertyName("versionType")]
    public EncryptionVersionTypeConstant? VersionType { get; set; }
}
