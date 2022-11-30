using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.AssetsAndAssetFilters;


internal class AssetPropertiesModel
{
    [JsonPropertyName("alternateId")]
    public string? AlternateId { get; set; }

    [JsonPropertyName("assetId")]
    public string? AssetId { get; set; }

    [JsonPropertyName("container")]
    public string? Container { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("storageAccountName")]
    public string? StorageAccountName { get; set; }

    [JsonPropertyName("storageEncryptionFormat")]
    public AssetStorageEncryptionFormatConstant? StorageEncryptionFormat { get; set; }
}
