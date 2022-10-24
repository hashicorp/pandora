using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.BatchAccount;


internal class BatchAccountCreatePropertiesModel
{
    [JsonPropertyName("allowedAuthenticationModes")]
    public List<AuthenticationModeConstant>? AllowedAuthenticationModes { get; set; }

    [JsonPropertyName("autoStorage")]
    public AutoStorageBasePropertiesModel? AutoStorage { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionPropertiesModel? Encryption { get; set; }

    [JsonPropertyName("keyVaultReference")]
    public KeyVaultReferenceModel? KeyVaultReference { get; set; }

    [JsonPropertyName("poolAllocationMode")]
    public PoolAllocationModeConstant? PoolAllocationMode { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccess { get; set; }
}
