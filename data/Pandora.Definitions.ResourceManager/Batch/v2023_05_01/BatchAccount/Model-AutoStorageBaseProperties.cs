using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_05_01.BatchAccount;


internal class AutoStorageBasePropertiesModel
{
    [JsonPropertyName("authenticationMode")]
    public AutoStorageAuthenticationModeConstant? AuthenticationMode { get; set; }

    [JsonPropertyName("nodeIdentityReference")]
    public ComputeNodeIdentityReferenceModel? NodeIdentityReference { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }
}
