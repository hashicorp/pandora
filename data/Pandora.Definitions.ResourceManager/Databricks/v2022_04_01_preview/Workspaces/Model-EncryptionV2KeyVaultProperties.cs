using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Databricks.v2022_04_01_preview.Workspaces;


internal class EncryptionV2KeyVaultPropertiesModel
{
    [JsonPropertyName("keyName")]
    [Required]
    public string KeyName { get; set; }

    [JsonPropertyName("keyVaultUri")]
    [Required]
    public string KeyVaultUri { get; set; }

    [JsonPropertyName("keyVersion")]
    [Required]
    public string KeyVersion { get; set; }
}
