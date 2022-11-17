using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Workspaces;


internal class EncryptionKeyVaultPropertiesModel
{
    [JsonPropertyName("identityClientId")]
    public string? IdentityClientId { get; set; }

    [JsonPropertyName("keyIdentifier")]
    [Required]
    public string KeyIdentifier { get; set; }

    [JsonPropertyName("keyVaultArmId")]
    [Required]
    public string KeyVaultArmId { get; set; }
}
