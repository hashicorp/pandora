using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;


internal class KeyVaultKeyReferenceModel
{
    [JsonPropertyName("keyUrl")]
    [Required]
    public string KeyUrl { get; set; }

    [JsonPropertyName("sourceVault")]
    [Required]
    public KeyVaultKeyReferenceSourceVaultModel SourceVault { get; set; }
}
