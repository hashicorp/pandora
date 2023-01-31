using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.StorageAccountCredentials;


internal class StorageAccountCredentialPropertiesModel
{
    [JsonPropertyName("accountKey")]
    public AsymmetricEncryptedSecretModel? AccountKey { get; set; }

    [JsonPropertyName("accountType")]
    [Required]
    public AccountTypeConstant AccountType { get; set; }

    [JsonPropertyName("alias")]
    [Required]
    public string Alias { get; set; }

    [JsonPropertyName("blobDomainName")]
    public string? BlobDomainName { get; set; }

    [JsonPropertyName("connectionString")]
    public string? ConnectionString { get; set; }

    [JsonPropertyName("sslStatus")]
    [Required]
    public SSLStatusConstant SslStatus { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
