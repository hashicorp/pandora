using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.NetAppAccounts;


internal class KeyVaultPropertiesModel
{
    [JsonPropertyName("keyName")]
    [Required]
    public string KeyName { get; set; }

    [JsonPropertyName("keyVaultId")]
    public string? KeyVaultId { get; set; }

    [JsonPropertyName("keyVaultResourceId")]
    [Required]
    public string KeyVaultResourceId { get; set; }

    [JsonPropertyName("keyVaultUri")]
    [Required]
    public string KeyVaultUri { get; set; }

    [JsonPropertyName("status")]
    public KeyVaultStatusConstant? Status { get; set; }
}
