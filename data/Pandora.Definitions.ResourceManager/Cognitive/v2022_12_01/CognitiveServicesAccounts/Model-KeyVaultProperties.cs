using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CognitiveServicesAccounts;


internal class KeyVaultPropertiesModel
{
    [JsonPropertyName("identityClientId")]
    public string? IdentityClientId { get; set; }

    [JsonPropertyName("keyName")]
    public string? KeyName { get; set; }

    [JsonPropertyName("keyVaultUri")]
    public string? KeyVaultUri { get; set; }

    [JsonPropertyName("keyVersion")]
    public string? KeyVersion { get; set; }
}
