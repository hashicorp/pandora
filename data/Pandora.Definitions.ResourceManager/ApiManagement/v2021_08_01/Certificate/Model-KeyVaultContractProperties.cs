using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Certificate;


internal class KeyVaultContractPropertiesModel
{
    [JsonPropertyName("identityClientId")]
    public string? IdentityClientId { get; set; }

    [JsonPropertyName("lastStatus")]
    public KeyVaultLastAccessStatusContractPropertiesModel? LastStatus { get; set; }

    [JsonPropertyName("secretIdentifier")]
    public string? SecretIdentifier { get; set; }
}
