using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.Namespaces;


internal class EncryptionModel
{
    [JsonPropertyName("keySource")]
    public KeySourceConstant? KeySource { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public List<KeyVaultPropertiesModel>? KeyVaultProperties { get; set; }

    [JsonPropertyName("requireInfrastructureEncryption")]
    public bool? RequireInfrastructureEncryption { get; set; }
}
