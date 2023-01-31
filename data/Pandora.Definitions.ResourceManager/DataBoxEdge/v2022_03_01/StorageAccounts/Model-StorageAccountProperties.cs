using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.StorageAccounts;


internal class StorageAccountPropertiesModel
{
    [JsonPropertyName("blobEndpoint")]
    public string? BlobEndpoint { get; set; }

    [JsonPropertyName("containerCount")]
    public int? ContainerCount { get; set; }

    [JsonPropertyName("dataPolicy")]
    [Required]
    public DataPolicyConstant DataPolicy { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("storageAccountCredentialId")]
    public string? StorageAccountCredentialId { get; set; }

    [JsonPropertyName("storageAccountStatus")]
    public StorageAccountStatusConstant? StorageAccountStatus { get; set; }
}
