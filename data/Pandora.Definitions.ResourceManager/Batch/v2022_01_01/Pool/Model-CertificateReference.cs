using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Pool;


internal class CertificateReferenceModel
{
    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [JsonPropertyName("storeLocation")]
    public CertificateStoreLocationConstant? StoreLocation { get; set; }

    [JsonPropertyName("storeName")]
    public string? StoreName { get; set; }

    [JsonPropertyName("visibility")]
    public List<CertificateVisibilityConstant>? Visibility { get; set; }
}
