using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01.Workspaces;


internal class EncryptionV2Model
{
    [JsonPropertyName("keySource")]
    [Required]
    public EncryptionKeySourceConstant KeySource { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public EncryptionV2KeyVaultPropertiesModel? KeyVaultProperties { get; set; }
}
